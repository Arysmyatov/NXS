using System.Threading.Tasks;

namespace NXS.Core
{
    public interface IExcelImportDataService
    {
        string WorkBookBasePath  { get; set; }

        Task ImportData();
        
    }
}