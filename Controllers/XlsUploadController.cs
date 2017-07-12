using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NXS.Controllers.Resources;
using NXS.Core;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Controllers
{

    public class XlsUploadController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IMapper mapper;
        private readonly IXlsService xlsService;
        private readonly XlsUploadSettings xlsUploadSettings;
        private readonly IXlsUploadRepository xlsUploadRepository;

        public XlsUploadController(IHostingEnvironment host, IXlsUploadRepository xlsUploadRepository, IMapper mapper, IOptionsSnapshot<XlsUploadSettings> options, IXlsService xlsService)
        {
            this.xlsUploadRepository = xlsUploadRepository;
            this.xlsService = xlsService;
            this.xlsUploadSettings = options.Value;
            this.mapper = mapper;
            this.host = host;
        }

        [HttpPost]
        [Route("/api/region/{regionId}/scenario/{scenarioId}/keyparameterlevel/{keyparameterLevelId}/xls")]
        public async Task<IActionResult> Upload(int regionId, int keyparameterLevelId, int scenarioId, IFormFile file)
        {
            if (file == null) return BadRequest("Null file");
            if (file.Length == 0) return BadRequest("Empty file");
            if (file.Length > xlsUploadSettings.MaxBytes) return BadRequest("Max file size exceeded");
            if (!xlsUploadSettings.IsSupported(file.FileName)) return BadRequest("Invalid file type.");

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            var xlsFile = await xlsService.UploadFile(regionId, keyparameterLevelId, scenarioId, file, uploadsFolderPath);

            return Ok(mapper.Map<XlsUpload, XlsUploadResource>(xlsFile));
        }

        [HttpGet]
        [Route("/api/region/{regionId}/scenario/{scenarioId}/keyparameterlevel/{keyparameterLevelId}/xls")]
        public async Task<IEnumerable<XlsUploadResource>> GetXlsFiles(int regionId, int scenarioId, int keyparameterLevelId)
        {
            var xlsFiles = await xlsService.GetXlsUploads(regionId, keyparameterLevelId, scenarioId);

            if(xlsFiles == null) return null;

            return mapper.Map<List<XlsUpload>, List<XlsUploadResource>>(xlsFiles.ToList());
        }
    }
}