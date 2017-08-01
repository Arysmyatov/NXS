using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Controllers
{
    [Route("/api/xlsregiontypes")]
    public class XlsRegionTypeController : Controller
    {

        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public XlsRegionTypeController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<XlsRegionTypeResource>> GetXlsRegionTypes()
        {
            var regionTypes = await context.XlsRegionTypes.ToListAsync();

            var variableResource = mapper.Map<List<XlsRegionType>, List<XlsRegionTypeResource>>(regionTypes);
            return variableResource;
        }        
    }
}