using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Core.Helpers;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Controllers
{

    [Route("/api/account")]
    public class AccountController : Controller
    {
        private readonly NxsDbContext _context;
        private readonly IMapper _mapper;

        private readonly UserManager<NxsUser> _userManager;

        private readonly IHttpContextAccessor _contextAccessor;

        public AccountController(NxsDbContext context, IMapper mapper, UserManager<NxsUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            this._context = context;
            this._userManager = userManager;
            this._contextAccessor = httpContextAccessor;
        }


        [HttpGet]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var nxsUser = await _userManager.FindByNameAsync(userName);
            if (nxsUser == null)
            {
                return NotFound();
            }
            var userProfile = _mapper.Map<UserProfileResource>(nxsUser);

            return Ok(userProfile);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationInfoResource model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<NxsUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            return Ok(model);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody]UserProfileResource model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var nxsUser = await _userManager.FindByNameAsync(userName);
            if (nxsUser == null)
            {
                return NotFound(model);
            }
            
            nxsUser = _mapper.Map<UserProfileResource, NxsUser>(model, nxsUser);

            var result = await _userManager.UpdateAsync(nxsUser);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            return Ok(model);
        }
    }
}