using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Core;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Controllers
{
    [Route("/api/data")]
    public class DataController : Controller
    {

        private readonly NxsDbContext context;
        private readonly IDataRepository repository;
        private readonly IMapper mapper;

        public DataController(NxsDbContext context, IDataRepository dataRepository, IMapper mapper)
        {
            this.context = context;
            this.repository = dataRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DataResource>> GetData()
        {
            var data = await context.Data.ToListAsync();
            return mapper.Map<List<Data>, List<DataResource>>(data);
        }


        [HttpGet]
        public async Task<DataResource> GetData(DataQueryResource filterResource)
        {
            var filter = mapper.Map<DataQueryResource, DataQuery>(filterResource);
            var queryResult = await repository.GetData(filter);

            var newDataResource = new DataResource();

            if (queryResult == null ||
              !queryResult.Items.Any())
            {
                return newDataResource;
            }

            var years = queryResult.Items.Select(i => i.Year).Distinct();
            var subVariables = queryResult.Items.Select(i => i.SubVariable.Name).Distinct().ToList();

            newDataResource.Years = years;
            newDataResource.SubVariables = subVariables;
            newDataResource.Values = new List<decimal[]>();

            for (var i = 0; i < subVariables.Count(); i++)
            {
                var items = queryResult.Items.Where(d => d.SubVariable.Name == subVariables[i]).Select(d => d.Value).ToArray();
                newDataResource.Values.Add(items);
            }

            return newDataResource;
        }

    }
}