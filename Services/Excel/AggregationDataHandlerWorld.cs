using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract;
using OfficeOpenXml;

namespace NXS.Services.Excel
{
    public class AggregationDataHandlerWorld : AggregationDataHandlerAbstract
    {

        public AggregationDataHandlerWorld(IExcelImportDataService excelImportDataService) :
                                                                    base(excelImportDataService)
        {
        }

        public override async Task<IEnumerable<SubVariableData>> GetDataFromXlsAsync()
        {
            _agrigationXlsDescription = _excelImportDataService.CurrentAgrigationXlsDescription;
            _currentRegionAgrigationTypeId = _excelImportDataService.CurrentAgrigationXlsDescription.RegionAgrigationTypeId;

            _subVariableDataList = new List<SubVariableData>();
            SetCurrentWorkSheet();
            GetYears();

            var region = await _excelImportDataService.RegionRepository.GetWorldRegion();
            _currentRegionId = region.Id;

            for (var row = _agrigationXlsDescription.RowBg; row <= _agrigationXlsDescription.RowEnd; row++)
            {
                try
                {
                    await SetCurrentAttributes(row);
                    AddSubVariables(row);
                }
                catch (Exception)
                {
                    // ToDo: log exception
                    continue;
                }
            }

            return _subVariableDataList;
        }


        public override async Task InsertDataToDbAsync(IEnumerable<SubVariableData> subVariableData)
        {
            foreach (var subVariableDataItem in subVariableData)
            {
                _excelImportDataService.SubVariableDataRepository.Add(subVariableDataItem);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
        }
    }
}