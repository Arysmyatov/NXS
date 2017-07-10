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

namespace NXS.Controllers
{
    [Route("api/[controller]")]
    public class ExportDataController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly NxsDbContext context;

        public ExportDataController(IHostingEnvironment hostingEnvironment, NxsDbContext context)
        {
            this.context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet("[action]")]
        public IActionResult XlsData()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var xlsService = new ExcelService();

            xlsService.WorkBookBasePath = contentRootPath + "/wwwroot/data/test";
            xlsService.VariablesXls = context.VariableXls.ToList();
            xlsService.KeyParameters = context.KeyParameters.ToList();
            var keyParameterLevel = context.KeyParameterLevels.First();

            var region = context.Regions.FirstOrDefault(r => r.Name == "UKI");
            var scenario = context.Scenarios.FirstOrDefault(r => r.Name == "Low Carbon");

            var data = xlsService.GetDataFromXls(region, scenario, keyParameterLevel);

            // Remove all the data before new adding
            XlsRemoveAllData();

            foreach(var d in data){
                context.Data.Add(d);
                context.SaveChanges();
            }

            return Ok();
        }


        public void XlsRemoveAllData() {
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Data"); 
        }

    }
}
