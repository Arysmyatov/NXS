using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using NXS.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Services.Abstract.XlsImport;

namespace NXS.Controllers
{
    [Route("api/[controller]")]
    public class ImportDataController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IExcelImportDataService _excelImportDataService;
        private readonly IXlsImportVariableDataService _xlsImportVariableDataService;
        private readonly IXlsService _xlsService;

        private readonly NxsDbContext _context;

        public ImportDataController(IHostingEnvironment hostingEnvironment, 
                                    NxsDbContext context, 
                                    IXlsService xlsService, 
                                    IXlsImportVariableDataService xlsImportVariableDataService,
                                    IExcelImportDataService excelImportDataService)
        {
            _context = context;
            _xlsService = xlsService;
            _xlsImportVariableDataService = xlsImportVariableDataService;
            _excelImportDataService = excelImportDataService;
            _hostingEnvironment = hostingEnvironment;
        }

        // private readonly IXlsService xlsService;

        [HttpPost("[action]")]
        public async Task<IActionResult> XlsImportData()
        {
            // await XlsRemoveAllData();
            string webRootPath = _hostingEnvironment.WebRootPath;
            string uploadsPath = $"{_hostingEnvironment.ContentRootPath}/wwwroot/uploads"; ;

            //_excelImportDataService.WorkBookBasePath = contentRootPath + "/wwwroot/uploads";
            //await _excelImportDataService.ImportData();

            _xlsImportVariableDataService.SetWorkBookBasePath(uploadsPath);
            await _xlsImportVariableDataService.Import();

            return Ok();
        }

        public async Task XlsRemoveAllData() {
            await _context.Database.ExecuteSqlCommandAsync("DELETE FROM dbo.Data"); 
        }

    }
}
