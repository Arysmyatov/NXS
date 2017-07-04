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
    public class KeyParameterController : Controller
    {
        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public KeyParameterController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/keyparameters")]
        public async Task<IEnumerable<KeyParameterGroupResource>> GetKeyParameters()
        {
            var keyParameters = await context.KeyParameterGroups.Include(m => m.KeyParameters).ToListAsync();
            return mapper.Map<List<KeyParameterGroup>, List<KeyParameterGroupResource>>(keyParameters);
        }        
        
    }
}