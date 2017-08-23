using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Controllers
{
    public class RegionsController : Controller
    {
        private readonly NxsDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<NxsUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public RegionsController(NxsDbContext context,
                                 IMapper mapper,
                                 UserManager<NxsUser> userManager,
                                 IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.context = context;
            this._userManager = userManager;
            this._contextAccessor = httpContextAccessor;
        }

        [HttpGet("/api/regions")]
        [Authorize]
        public IActionResult GetRegions()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var nxsUser = context.Users.Where(u => u.UserName == userName)
                                        .Include(u => u.ParentRegion)
                                        .ThenInclude(pr => pr.Regions).FirstOrDefault();
            if (nxsUser == null)
            {
                return NotFound("User Not found");
            }

            return Ok(mapper.Map<ParentRegion, ParentRegionResource>(nxsUser.ParentRegion));
        }
    }
}