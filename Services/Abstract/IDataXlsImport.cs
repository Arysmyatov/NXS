using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;
using NXS.Services.Excel;

namespace NXS.Services.Abstract
{
    public interface IDataXlsImport<T>
    {
        Task<IEnumerable<T>> GetDataFromXlsAsync();
        Task InsertDataToDbAsync(IEnumerable<T> variableData);
    }
}