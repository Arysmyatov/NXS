using System.Threading.Tasks;
using OfficeOpenXml;

namespace NXS.Services.Abstract.XlsImport
{
    public interface IXlsImportVariableDataService
    {
        int CurrentScenarioId { get; set; }
        int CurrentKeyParameterId { get; set; }
        int CurrentKeyParameterLevelId { get; set; }
        int CurrentParentRegionId { get; set; }

        ExcelWorkbook CurrentWorkBook { get; set; }
        Task Import();
        void SetWorkBookBasePath(string basePath);
    }
}