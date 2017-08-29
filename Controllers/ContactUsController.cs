using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Core;
using NXS.Core.Models;
using NXS.Persistence;
using NXS.Services.Abstract;

namespace NXS.Controllers
{
    [Route("/api/contactus")]
    public class ContactUsController : Controller
    {
        private readonly IMapper _mapper;        
        private readonly IUserActivityService _userActivityService;        

        public ContactUsController(IUserActivityService userActivityService, IMapper mapper)
        {
            _mapper = mapper;
            _userActivityService = userActivityService;
        }


        [HttpPost]        
        public async Task<IActionResult> PostEmail([FromBody] ContactUsMessageResource model)
        {
            var contactUsMessage = _mapper.Map<ContactUsMessage>(model);
            await _userActivityService.AddContactUsMessageAsync(contactUsMessage);
            return Ok(model);
        }
    }
}