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
    public class VariablesController : Controller
    {
        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public VariablesController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/variables")]
        public async Task<IEnumerable<VariableGroupResource>> GetVariables()
        {
            var variables = await context.VariableGroups.Include(m => m.Variables).ToListAsync();
            return mapper.Map<List<VariableGroup>, List<VariableGroupResource>>(variables);
        }
    }
}