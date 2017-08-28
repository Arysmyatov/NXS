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
        private readonly IEmailService _emailService;        

        public ContactUsController(IEmailService emailService)
        {
            this._emailService = emailService;
        }


        //public async Task<IActionResult> Post([FromBody] SaveVariableXlsResource variableXlsResource)
        [HttpPost]        
        public async Task<IActionResult> PostEmail()
        {
            await _emailService.SendEmailAsync("Contact us request", "Test");
            return Ok();
        }        
        
    }
}