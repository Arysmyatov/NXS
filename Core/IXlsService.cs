using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IXlsService
    {
        Task<XlsUpload> UploadFile(int regionId, int keyParameterId,  int keyParameterLevelId, int scenarioId, IFormFile file, string uploadsFolderPath);
        Task<IEnumerable<XlsUpload>> GetXlsUploads(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId);
        Task<XlsUpload> GetXlsLastUpload(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId);
    }
}