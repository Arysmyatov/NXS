using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IXlsUploadRepository
    {
        Task<IEnumerable<XlsUpload>> GetXlsUploadsAsync(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId);

        Task<XlsUpload> GetXlsLastUplodAsync(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId);

        void Add(XlsUpload vehicle);
    }
}