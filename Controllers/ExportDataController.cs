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
using static NXS.Services.VariableScope;
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

        private readonly NxsDbContext context;

        public ExportDataController(IHostingEnvironment hostingEnvironment, NxsDbContext context, IXlsService xlsService)
        {
            this.context = context;
            this.xlsService = xlsService;
            _hostingEnvironment = hostingEnvironment;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IXlsService xlsService;

        [HttpPost("[action]")]
        public async Task<IActionResult> XlsData()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var xlsService = new ExcelService();

            xlsService.WorkBookBasePath = contentRootPath + "/wwwroot/uploads";
            xlsService.VariablesXls = context.VariableXls.ToList();
            xlsService.KeyParameters = context.KeyParameters.ToList();

            var regions = context.Regions.ToList();
            var scenarios = context.Scenarios.ToList();
            var keyParameterLevels = context.KeyParameterLevels.ToList();

            // Remove all the data before new adding
            XlsRemoveAllData();

            foreach(var region in regions)
            {
                foreach (var scenario in scenarios)
                {   
                    foreach (var keyParameterLevel in keyParameterLevels)
                    {
                        var lastUploadedFile = await this.xlsService.GetXlsLastUpload(region.Id, keyParameterLevel.Id, scenario.Id);
                        if(lastUploadedFile == null || 
                            string.IsNullOrEmpty(lastUploadedFile.FileName)) continue;

                        var data = xlsService.GetDataFromXls(region, scenario, keyParameterLevel, lastUploadedFile.FileName);

                        foreach(var d in data) {
                            context.Data.Add(d);
                            context.SaveChanges();
                        }
                    }
                }
            }

            return Ok();
        }


        public void XlsRemoveAllData() {
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Data"); 
        }

    }
}
