

using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NXS.Controllers.Resources;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Controllers
{
    public class ParentRegionController : Controller
    {
        private readonly NxsDbContext _context;
        private readonly IMapper _mapper;

        public ParentRegionController(NxsDbContext context,
                                      IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("/api/parentregions")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetParentRegions()
        {
            var regions = _context.ParentRegions;

            return Ok(_mapper.Map<IEnumerable<ParentRegion>, IEnumerable<ParentRegionResource>>(regions));
        }
    }
}