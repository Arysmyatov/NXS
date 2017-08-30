using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Core
{
    public class XlsService : IXlsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NxsDbContext _context;        
        private readonly IXlsStorage xlsStorage;
        private readonly IXlsUploadRepository xlsUploadRepository;

        public XlsService(IUnitOfWork unitOfWork,
                            NxsDbContext context, 
                            IXlsUploadRepository xlsUploadRepository, 
                            IXlsStorage xlsStorage)
        {
            this.xlsStorage = xlsStorage;
            this._context = context;
            this._unitOfWork = unitOfWork;
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
            await _unitOfWork.CompleteAsync();

            return xlsUpload;
        }


        public async Task<XlsUpload> UploadFileWithRegion(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId, IFormFile file, string uploadsFolderPath)
        {
            var relationalPath = await GetFilePathAsync(regionId, keyParameterId, keyParameterLevelId, scenarioId);
            var xlsFileFullPath = Path.Combine(uploadsFolderPath, relationalPath);            
            var fileName = await xlsStorage.StoreXls(xlsFileFullPath, file);
            var relationalFileName = Path.Combine(relationalPath, fileName); 

            var xlsUpload = new XlsUpload
            {
                KeyParameterId = keyParameterId,
                KeyParameterLevelId = keyParameterLevelId,
                ScenarioId = scenarioId,
                FileName = relationalFileName,
                UploadDate = DateTime.Now
            };

            xlsUploadRepository.Add(xlsUpload);
            await _unitOfWork.CompleteAsync();

            return xlsUpload;
        }


        private async Task<string> GetFilePathAsync(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId)
        {
            var region = await _context.Regions.FindAsync(regionId);
            var keyParameter = await _context.KeyParameters.FindAsync(keyParameterId);
            var keyParameterLevel = await _context.KeyParameterLevels.FindAsync(keyParameterLevelId);
            var scenario = await _context.Scenarios.FindAsync(scenarioId);

            var filePath = $"{scenario.Name}/{keyParameter.Name}/{keyParameterLevel.Name}/{region.Name}";

            return filePath;
        }


    }
}