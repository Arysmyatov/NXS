using System.Threading.Tasks;
using NXS.Core.Models;
using OfficeOpenXml;

namespace NXS.Core
{
    public interface IExcelImportDataService
    {
        IUnitOfWork UnitOfWork { get; set; }

        IRegionRepository RegionRepository { get; set; }

        IProcessSetRepository ProcessSetRepository { get; set; }   

        ICommodityRepository CommodityRepository { get; set; }     

        ICommoditySetRepository CommoditySetRepository { get; set; }        

        IAttributeRepository AttributeRepository { get; set; }        

        IUserConstraintRepository UserConstraintRepository { get; set; }  
        
        IVariableDataRepository VariableDataRepository { get; set; }  
        
        ISubVariableDataRepository SubVariableDataRepository { get; set; }  
        
        ISubVariableRepository SubVariableRepository { get; set; }  

        VariableXlsDescription CurrentVariableXlsDescription { get; set; }

        AgrigationXlsDescription CurrentAgrigationXlsDescription { get; set; }

        int CurrentSecenarioId { get; set; }

        int CurrentVariableId { get; set; }

        int CurrentKeyParameterId { get; set; }

        int CurrentKeyParameterLevelId { get; set; }      

        ExcelWorkbook CurrentWorkBook { get; set; }

        string WorkBookBasePath  { get; set; }

        Task ImportData();
        
    }
}