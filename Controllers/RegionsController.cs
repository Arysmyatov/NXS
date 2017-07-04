using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Models;
using NXS.Persistence;

namespace NXS.Controllers
{
    public class RegionsController : Controller
    {
        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public RegionsController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/regions")]
        public async Task<IEnumerable<ParentRegionResource>> GetRegions()
        {
            var regions = await context.ParentRegions.Include(m => m.Regions).ToListAsync();
            return mapper.Map<List<ParentRegion>, List<ParentRegionResource>>(regions);
        }
    }
}