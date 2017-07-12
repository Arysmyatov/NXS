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
    public class ScenarioController : Controller
    {
        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public ScenarioController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/scenarios")]
        public async Task<IEnumerable<ScenarioResource>> GetScenarios()
        {
            var scenarios = await context.Scenarios.ToListAsync();
            return mapper.Map<List<Scenario>, List<ScenarioResource>>(scenarios);
        }
    }
}