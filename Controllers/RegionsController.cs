using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Core;
using NXS.Core.Models;
using NXS.Core.NxsConstants;
using NXS.Persistence;

namespace NXS.Controllers
{
    public class RegionsController : Controller
    {
        private readonly NxsDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<NxsUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IRegionRepository _regionRepository;

        public RegionsController(NxsDbContext context,
                                 IMapper mapper,
                                 UserManager<NxsUser> userManager,
                                 IHttpContextAccessor httpContextAccessor,
                                 IRegionRepository regionRepository)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _contextAccessor = httpContextAccessor;
            _regionRepository = regionRepository;
        }

        [HttpGet("/api/regions")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetRegions()
        {
            var userName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if(string.IsNullOrEmpty(userName)){
                return BadRequest("There is no user data in the request");
            }
            var user = _context.Users.Where(u => u.UserName == userName)
                                     .Include(u => u.ParentRegion).FirstOrDefault();

            if(user == null){
                return BadRequest("There is no user data in the request");
            }    
            if(user.ParentRegion == null){
                return BadRequest("There is no binded regions for the user");
            }    
            
            var userRegions = await _regionRepository.GetRegions(new RegionQuery{
                ParentRegionId = user.ParentRegion.Id
            });

            if(userRegions == null || userRegions.TotalItems == 0){
                return BadRequest("There is no binded regions for the user");
            }

            var result = userRegions.Items.ToList();
            var worldRegion = await _regionRepository.GetRegionByName(RegionConstants.WorldRegionName);
            result.Add(worldRegion);

            return Ok(_mapper.Map<IEnumerable<Region>, IEnumerable<RegionResource>>(result));
        }
    }
}