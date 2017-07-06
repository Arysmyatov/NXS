using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Models;
using NXS.Persistence;

namespace NXS.Controllers
{
    [Route("/api/data")]
    public class DataController : Controller
    {

        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public DataController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet()]
        public async Task<IEnumerable<DataResource>> GetData()
        {
            var data = await context.Data.ToListAsync();
            return mapper.Map<List<Data>, List<DataResource>>(data);
        }

        [HttpGet("region/{regionId}/scenario/{scenarioId}/variable/{variableId}/keyparameter/{keyparameterId}/level/{levelId}")]
        public async Task<IEnumerable<DataResource>> GetByParams(int regionId, int scenarioId, int variableId, int keyparameterId, int levelId)
        {
            var data = await context.Data.Where(d => d.RegionId == regionId && 
                                                     d.ScenarioId == scenarioId && 
                                                     d.VariableId == variableId && 
                                                     d.KeyParameterId == keyparameterId && 
                                                     d.KeyParameterLevelId == levelId).ToListAsync();

            return mapper.Map<List<Data>, List<DataResource>>(data);
        }
    }        
}