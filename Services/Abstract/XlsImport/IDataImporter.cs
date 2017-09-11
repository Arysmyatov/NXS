using System.Threading.Tasks;

namespace NXS.Services.Abstract.XlsImport
{
    public interface IDataImporter
    {
        IXlsImportVariableDataService XlsImportVariableDataService { get; set; }

        int CurrentRegionAggregationTypeId { get; set; }

        Task ImportDataAsync();

        Task RemoveDataAsync();
    }
}