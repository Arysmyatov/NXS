using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;
using NXS.Persistence;
using NXS.Services.Abstract;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions;
using OfficeOpenXml;

namespace NXS.Services.Excel
{
    public class ExcelImportDataService : IExcelImportDataService
    {
        public readonly IScenarioRepository ScenarioRepository;
        public IRegionRepository RegionRepository { get; set; }
        public IProcessSetRepository ProcessSetRepository { get; set; }
        public ICommodityRepository CommodityRepository { get; set; }
        public ICommoditySetRepository CommoditySetRepository { get; set; }
        public IAttributeRepository AttributeRepository { get; set; }
        public IUserConstraintRepository UserConstraintRepository { get; set; }
        public IVariableDataRepository VariableDataRepository { get; set; }
        public ISubVariableRepository SubVariableRepository { get; set; }
        public ISubVariableDataRepository SubVariableDataRepository { get; set; }
        private readonly AggregationSumCulculationService _aggregationSumCulculationService;
        private readonly AggregationSumWorldCulculationService _aggregationSumWorldCulculationService;
        private readonly IXlsFormulaUpdaterService _xlsFormulaUpdaterService;
        private readonly IVariableRepository _variableRepository;
        private readonly IVariableXlsDescriptionRepository _variableXlsDescriptionRepository;
        private readonly IAgrigationXlsDescriptionRepository _agrigationXlsDescriptionRepository;
        private readonly IRegionAgrigationTypeRepository _regionAgrigationTypeRepository;
        private readonly IDataRepository _dataRepository;
        private readonly NxsDbContext _context;
        private readonly IDataXlsImport<VariableData> _variableDataHandler;
        private readonly IDataXlsImport<SubVariableData> _aggregationDataHandlerGdp;
        private readonly AggregationDataHandlerAbstract _agrigationDataHandler;
        private readonly AggregationDataHandlerAbstract _agrigationDataHandlerWorld;
        public IUnitOfWork UnitOfWork { get; set; }
        public ExcelWorkbook CurrentWorkBook { get; set; }
        public int CurrentSecenarioId { get; set; }
        public int CurrentKeyParameterId { get; set; }
        public int CurrentKeyParameterLevelId { get; set; }
        public int CurrentVariableId { get; set; }
        public int CurrentRegionId { get; set; }
        public VariableXlsDescription CurrentVariableXlsDescription { get; set; }
        public AgrigationXlsDescription CurrentAgrigationXlsDescription { get; set; }
        public string WorkBookBasePath { get; set; }

        //private readonly ILogger _logger;

        public ExcelImportDataService(IScenarioRepository scenarioRepository,
                                        IRegionRepository regionRepository,
                                        IVariableRepository variableRepository,
                                        IVariableXlsDescriptionRepository variableXlsDescriptionRepository,
                                        IAgrigationXlsDescriptionRepository agrigationXlsDescriptionRepository,
                                        ISubVariableRepository subVariableRepository,
                                        ISubVariableDataRepository subVariableDataRepository,
                                        IProcessSetRepository processSetRepository,
                                        ICommodityRepository commodityRepository,
                                        ICommoditySetRepository commoditySetRepository,
                                        IAttributeRepository attributeRepository,
                                        IUserConstraintRepository userConstraintRepository,
                                        IVariableDataRepository variableDataRepository,
                                        IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                        AggregationSumCulculationService aggregationSumulCalculationService,
                                        AggregationSumWorldCulculationService aggregationSumWorldCulculationService,
                                        IXlsFormulaUpdaterService xlsFormulaUpdaterService,
                                        IDataRepository dataRepository,
                                        IUnitOfWork unitOfWork,
                                        //ILogger<ExcelImportDataService> logger,
                                        NxsDbContext context)
        {
            ScenarioRepository = scenarioRepository;
            RegionRepository = regionRepository;
            ProcessSetRepository = processSetRepository;
            CommodityRepository = commodityRepository;
            CommoditySetRepository = commoditySetRepository;
            AttributeRepository = attributeRepository;
            UserConstraintRepository = userConstraintRepository;
            VariableDataRepository = variableDataRepository;
            SubVariableRepository = subVariableRepository;
            SubVariableDataRepository = subVariableDataRepository;
            _aggregationSumCulculationService = aggregationSumulCalculationService;
            _aggregationSumWorldCulculationService = aggregationSumWorldCulculationService;
            _xlsFormulaUpdaterService = xlsFormulaUpdaterService;
            _variableRepository = variableRepository;
            _variableXlsDescriptionRepository = variableXlsDescriptionRepository;
            _agrigationXlsDescriptionRepository = agrigationXlsDescriptionRepository;
            _dataRepository = dataRepository;
            _context = context;
            UnitOfWork = unitOfWork;
            //_logger = logger;
            _variableDataHandler = new VariableDataHandler(this);
            _agrigationDataHandler = new AggregationDataHandler(this);
            _agrigationDataHandlerWorld = new AggregationDataHandlerWorld(this);
            _aggregationDataHandlerGdp = new AggregationDataHandlerGdp(this);
        }

        public async Task ImportData()
        {
            var scenarios = await _context.Scenarios.ToListAsync();

            foreach (var scenario in scenarios)
            {
                CurrentSecenarioId = scenario.Id;
                var keyParameters = _context.KeyParameters.ToList();

                foreach (var keyParameter in keyParameters)
                {
                    CurrentKeyParameterId = keyParameter.Id;

                    var keyParameterLevels = _context.KeyParameterLevels.ToList();
                    foreach (var keyParameterLevel in keyParameterLevels)
                    {
                        CurrentKeyParameterLevelId = keyParameterLevel.Id;
                        var xlsFile = _context.XlsUploads.FirstOrDefault(x => x.ScenarioId == scenario.Id &&
                                                                              x.KeyParameterId == keyParameter.Id &&
                                                                              x.KeyParameterLevelId == keyParameterLevel.Id);
                        if (xlsFile == null)
                        {
                            continue;
                        }

                        // Open file
                        var filePath = $"{WorkBookBasePath}/{xlsFile.FileName}";
                        var fileInfo = new FileInfo(filePath);

                        // Open Xls file
                        using (var package = new ExcelPackage(fileInfo))
                        {
                            this.CurrentWorkBook = package.Workbook;

                            // update all formulas in xls file
                            UpdateXlsFormulas();
                            package.Save();

                            // get Variable Data
                            // await GetVariableDataAggreegation();

                            // get Sub Variable data
                            //await GetSubVariableDataAggregategation();

                            // get Sub Variable GDP 
                            //await GetSubVariableDataAggregategationGdp();

                            // get Sub Variable World data
                            //await GetSubVariableDataAggregategationWorld();
                        }
                    }
                }
            }

            //await CalculateSums();
            //await CalculateWorldSums();
        }


        private void UpdateXlsFormulas()
        {
            _xlsFormulaUpdaterService.VariableDescriptions = XlsVariableDescriptions.AllDescriptions;
            _xlsFormulaUpdaterService.SetWorkbook(this.CurrentWorkBook);
            _xlsFormulaUpdaterService.Update();
        }


        public async Task ImportDataDirect()
        {
            // Get All not processe xls files 
            var notProcessedxlsFiles = await _context.XlsUploads.Where(x => x.IsProcessed == false).ToArrayAsync();
            foreach (var xlsFileDescription in notProcessedxlsFiles)
            {
                SetCurrentFilterVariables(xlsFileDescription);
            }



        }

        private void SetCurrentFilterVariables(XlsUpload xlsFileDescription)
        {
            CurrentSecenarioId = xlsFileDescription.ScenarioId;
            CurrentKeyParameterId = xlsFileDescription.KeyParameterId;
            CurrentKeyParameterLevelId = xlsFileDescription.KeyParameterLevelId;
            CurrentRegionId = xlsFileDescription.RegionId == null ? 0 : xlsFileDescription.RegionId.Value;
        }


        #region private methods 

        private async Task GetVariableDataAggreegation()
        {
            var variableXlsDescriptions = _variableXlsDescriptionRepository.GetVariableXlsDescriptions().ToArray();
            foreach (var variableXlsDescription in variableXlsDescriptions)
            {
                this.CurrentVariableXlsDescription = variableXlsDescription;
                this.CurrentVariableId = this.CurrentVariableXlsDescription.VariableId;
                var data = await _variableDataHandler.GetDataFromXlsAsync();
                await _variableDataHandler.InsertDataToDbAsync(data);
            }
        }


        private async Task GetSubVariableDataAggregategation()
        {
            var agrigationXlsDescriptions = _agrigationXlsDescriptionRepository.GetDescriptions().ToArray();
            foreach (var agrigationXlsDescription in agrigationXlsDescriptions)
            {
                this.CurrentAgrigationXlsDescription = agrigationXlsDescription;
                this.CurrentVariableId = this.CurrentAgrigationXlsDescription.VariableId;
                var data = await _agrigationDataHandler.GetDataFromXlsAsync();
                await _agrigationDataHandler.InsertDataToDbAsync(data);
            }
        }


        private async Task GetSubVariableDataAggregategationGdp()
        {
            var agrigationXlsDescriptions = _agrigationXlsDescriptionRepository.GetDescriptionsGdp().ToArray();
            foreach (var agrigationXlsDescription in agrigationXlsDescriptions)
            {
                this.CurrentAgrigationXlsDescription = agrigationXlsDescription;
                this.CurrentVariableId = this.CurrentAgrigationXlsDescription.VariableId;
                var data = await _aggregationDataHandlerGdp.GetDataFromXlsAsync();
                await _aggregationDataHandlerGdp.InsertDataToDbAsync(data);
            }
        }


        private async Task GetSubVariableDataAggregategationWorld()
        {
            var agrigationXlsDescriptionsWorld = _agrigationXlsDescriptionRepository.GetWorldDescriptions().ToArray();
            foreach (var agrigationXlsDescription in agrigationXlsDescriptionsWorld)
            {
                this.CurrentAgrigationXlsDescription = agrigationXlsDescription;
                this.CurrentVariableId = this.CurrentAgrigationXlsDescription.VariableId;
                var data = await _agrigationDataHandlerWorld.GetDataFromXlsAsync();
                await _agrigationDataHandlerWorld.InsertDataToDbAsync(data);
            }
        }

        private async Task CalculateSums()
        {
            await _aggregationSumCulculationService.UpdateSumsAsync();
        }

        private async Task CalculateWorldSums()
        {
            await _aggregationSumWorldCulculationService.UpdateSumsAsync();
        }

        #endregion private methods 

    }
}