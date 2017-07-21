using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NXS.Core.Models;

namespace NXS.Core
{
    public class XlsService : IXlsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IXlsStorage xlsStorage;
        private readonly IXlsUploadRepository xlsUploadRepository;

        public XlsService(IUnitOfWork unitOfWork, IXlsUploadRepository xlsUploadRepository, IXlsStorage xlsStorage)
        {
            this.xlsStorage = xlsStorage;
            this.unitOfWork = unitOfWork;
            this.xlsUploadRepository = xlsUploadRepository;
        }

        public async Task<IEnumerable<XlsUpload>> GetXlsUploads(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId)
        {
            var uploads = await xlsUploadRepository.GetXlsUploadsAsync(regionId, keyParameterId, keyParameterLevelId, scenarioId);
            return uploads;
        }

        public async Task<XlsUpload> GetXlsLastUpload(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId)
        {
            var upload = await xlsUploadRepository.GetXlsLastUplodAsync(regionId, keyParameterId, keyParameterLevelId, scenarioId);
            return upload;
        }
        

        public async Task<XlsUpload> UploadFile(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await xlsStorage.StoreXls(uploadsFolderPath, file);

            var xlsFile = new XlsUpload { FileName = fileName };

            var xlsUpload = new XlsUpload
            {
                KeyParameterId = keyParameterId,
                KeyParameterLevelId = keyParameterLevelId,
                ScenarioId = scenarioId,
                FileName = fileName,
                UploadDate = DateTime.Now
            };

            xlsUploadRepository.Add(xlsUpload);
            await unitOfWork.CompleteAsync();

            return xlsUpload;
        }
    }
}