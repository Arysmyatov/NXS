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
    [ResponseCache(Duration = 3600)]
    public class KeyParameterLevelController : Controller
    {
        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public KeyParameterLevelController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/keyparameterlevels")]
        public async Task<IEnumerable<KeyParameterLevelResource>> GetKeyParameterLevels()
        {
            var keyParameterLevels = await context.KeyParameterLevels.ToListAsync();
            return mapper.Map<List<KeyParameterLevel>, List<KeyParameterLevelResource>>(keyParameterLevels);
        }        
        
    }
}