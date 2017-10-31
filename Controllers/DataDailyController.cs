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
using NXS.Controllers.Resources;
using NXS.Core;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Controllers
{

    [Route("/api/dailydata")]
    public class DataDailyController : Controller
    {
        private readonly NxsDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubVariableDailyDataRepository _subVariableDailyDataRepository;
        private readonly ISubVariableDataRepository _subVariablesData;
        private readonly IMapper _mapper;
        private NxsUser _currentUser;

        private readonly IHttpContextAccessor _contextAccessor;


        #region Constructors

        public DataDailyController(NxsDbContext context,
                                   IUnitOfWork unitOfWork,
                                   ISubVariableDailyDataRepository subVariableDailyDataRepository,
                                   IHttpContextAccessor httpContextAccessor,
                                   IMapper mapper)
        {
            this._context = context;
            this._unitOfWork = unitOfWork;
            this._subVariableDailyDataRepository = subVariableDailyDataRepository;
            this._mapper = mapper;
            this._contextAccessor = httpContextAccessor;
        }

        #endregion Constructors


        #region Public actions

//        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] DataQueryResource filterResource)
        {
            // if (CurrentUser == null)
            // {
            //     return BadRequest("There is no user with the User Name");
            // }

            var dataResourceResult = new List<DataDailyResource>();

            foreach (var keyParameterResource in filterResource.KeyParameterResources)
            {
                dataResourceResult.Add(GetDataResource(filterResource, keyParameterResource));
            }

            return Ok(dataResourceResult);
        }


        #endregion Public actions        


        #region private methods

        private DataDailyResource GetDataResource(DataQueryResource filterResource,
                                                  KeyParameterResource keyParameterResource)
        {
            // var filter = _mapper.Map<DataQueryResource, SubVariableDataQuery>(filterResource);
            // filter.IsPaging = false;
            // filter.KeyParameterId = keyParameterResource.Id;
            // filter.KeyParameterLevelId = keyParameterResource.KeyParameterLevelId;
            // filter.ParentRegionId = CurrentUser.ParentRegionId;

            var result = _subVariableDailyDataRepository.GetSubVariableData();

            var newDataResource = new DataDailyResource
            {
                KeyParameterId = keyParameterResource.Id,
                KeyParameterLevelId = keyParameterResource.KeyParameterLevelId
            };

            if (result == null ||
               !result.Any())
            {
                return newDataResource;
            }

            var dates = result.Select(i => $"{i.Year}-{i.Month}").OrderBy(y => y).Distinct();
            var subVariables = result.Select(i => i.SubVariable.Name).Distinct().ToList();

            newDataResource.Date = dates;
            newDataResource.SubVariables = subVariables;
            newDataResource.Values = new List<decimal[]>();

            for (var i = 0; i < subVariables.Count(); i++)
            {
                var items = result.Where(d => d.SubVariable.Name == subVariables[i])
                                             .OrderBy(y => y.Year).OrderBy(y => y.Month)
                                             .Select(d => d.Value).ToArray();
                var itemsToAdd = new decimal[dates.Count()];
                for (var j = 0; j < items.Length; j++)
                {
                    itemsToAdd[j] = items[j];
                }
                newDataResource.Values.Add(itemsToAdd);
            }                

            return newDataResource;            
        }


        private NxsUser CurrentUser
        {
            get
            {
                if (_currentUser != null)
                {
                    return _currentUser;
                }
                var userName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                _currentUser = _context.Users.Where(u => u.UserName == userName).FirstOrDefault();
                return _currentUser;
            }
        }


        #endregion private methods

    }
}