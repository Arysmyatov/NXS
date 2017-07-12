using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NXS.Core
{
    public interface IXlsStorage
    {
         Task<string> StoreXls(string uploadsFolderPath, IFormFile file);
    }
}