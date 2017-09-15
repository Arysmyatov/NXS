using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly ISubVariableDataRepository _subVariablesData;
        private readonly IMapper mapper;

        private readonly IHttpContextAccessor _contextAccessor;

        private NxsUser _currentUser;

        private NxsUser CurrentUser
        {
            get
            {
                if (_currentUser != null)
                {
                    return _currentUser;
                }
                var userName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                _currentUser = context.Users.Where(u => u.UserName == userName).FirstOrDefault();
                return _currentUser;
            }
        }

        public DataController(NxsDbContext context,
                              IDataRepository dataRepository,
                              ISubVariableDataRepository subVariableDataRepository,
                              IHttpContextAccessor httpContextAccessor,
                              IMapper mapper)
        {
            this.context = context;
            this.repository = dataRepository;
            this._subVariablesData = subVariableDataRepository;
            this.mapper = mapper;
            _contextAccessor = httpContextAccessor;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] DataQueryResource filterResource)
        {
            if (CurrentUser == null)
            {
                return BadRequest("There is no user with the User Name");
            }

            var dataResourceResult = new List<DataResource>();

            foreach (var keyParameterResource in filterResource.KeyParameterResources)
            {
                dataResourceResult.Add(await GetDataResourceAsync(filterResource, keyParameterResource));
            }

            return Ok(dataResourceResult);
        }


        private async Task<DataResource> GetDataResourceAsync(DataQueryResource filterResource,
                                                              KeyParameterResource keyParameterResource)
        {
            var filter = mapper.Map<DataQueryResource, SubVariableDataQuery>(filterResource);
            filter.IsPaging = false;
            filter.KeyParameterId = keyParameterResource.Id;
            filter.KeyParameterLevelId = keyParameterResource.KeyParameterLevelId;
            filter.ParentRegionId = CurrentUser.ParentRegionId;

            var queryResult = await _subVariablesData.GetSubVariableData(filter, true);

            var newDataResource = new DataResource
            {
                KeyParameterId = keyParameterResource.Id,
                KeyParameterLevelId = keyParameterResource.KeyParameterLevelId
            };

            if (queryResult == null ||
              !queryResult.Items.Any())
            {
                return newDataResource;
            }

            var years = queryResult.Items.Select(i => i.Year).OrderBy(y => y).Distinct();
            var subVariables = queryResult.Items.Select(i => i.SubVariable.Name).Distinct().ToList();

            newDataResource.Years = years;
            newDataResource.SubVariables = subVariables;
            newDataResource.Values = new List<decimal[]>();

            for (var i = 0; i < subVariables.Count(); i++)
            {
                var items = queryResult.Items.Where(d => d.SubVariable.Name == subVariables[i])
                                             .OrderBy(y => y.Year)
                                             .Select(d => d.Value).ToArray();
                var itemsToAdd = new decimal[years.Count()];
                for (var j = 0; j < items.Length; j++)
                {
                    itemsToAdd[j] = items[j];
                }
                newDataResource.Values.Add(itemsToAdd);
            }

            return newDataResource;
        }

    }
}