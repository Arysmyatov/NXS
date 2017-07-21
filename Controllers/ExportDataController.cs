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

namespace NXS.Controllers
{
    [Route("api/[controller]")]
    public class ExportDataController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IExcelImportDataService _excelImportDataService;
        private readonly IXlsService _xlsService;

        private readonly NxsDbContext _context;

        public ExportDataController(IHostingEnvironment hostingEnvironment, NxsDbContext context, IXlsService xlsService, IExcelImportDataService excelImportDataService)
        {
            _context = context;
            _xlsService = xlsService;
            _excelImportDataService = excelImportDataService;
            _hostingEnvironment = hostingEnvironment;
        }

        private readonly IXlsService xlsService;

        [HttpPost("[action]")]
        public async Task<IActionResult> XlsImportData()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            _excelImportDataService.WorkBookBasePath = contentRootPath + "/wwwroot/uploads";
            await _excelImportDataService.ImportData();

            return Ok();
        }

        public async Task XlsRemoveAllData() {
            await _context.Database.ExecuteSqlCommandAsync("DELETE FROM dbo.Data"); 
        }

    }
}
