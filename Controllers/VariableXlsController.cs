using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NXS.Controllers.Resources;
using NXS.Core.Models;
using NXS.Persistence;


namespace NXS.Controllers
{
    [Route("/api/variablexls")]
    public class VariableXlsController : Controller
    {
        private readonly NxsDbContext context;
        private readonly IMapper mapper;

        public VariableXlsController(NxsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetVariableXls(int id)
        {
            var variableXls = await context.VariableXls.SingleOrDefaultAsync(v => v.Id == id);

            if (variableXls == null)
                return NotFound();

            var variableResource = mapper.Map<VariableXls, VariableXlsResource>(variableXls);

            return Ok(variableResource);
        }


        [HttpGet]
        public async Task<IEnumerable<VariableXlsResource>> GetVariableXls()
        {
            var variableXls = await context.VariableXls.ToListAsync();

            var variableResource = mapper.Map<List<VariableXls>, List<VariableXlsResource>>(variableXls);
            return mapper.Map<List<VariableXls>, List<VariableXlsResource>>(variableXls);
        }


        [HttpPost]
        public async Task<IActionResult> CreateVariableXls([FromBody] SaveVariableXlsResource variableXlsResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var variableXls = mapper.Map<SaveVariableXlsResource, VariableXls>(variableXlsResource);
            context.VariableXls.Add(variableXls);
            await context.SaveChangesAsync();

            variableXls = await context.VariableXls.FirstOrDefaultAsync(v => v.Id == variableXls.Id);

            var result = mapper.Map<VariableXls, VariableXlsResource>(variableXls);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVariable(int id, [FromBody] SaveVariableXlsResource variableXlsResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var variableXls = await context.VariableXls.FirstOrDefaultAsync(v => v.Id == id);

            if (variableXls == null)
                return NotFound();

            mapper.Map<SaveVariableXlsResource, VariableXls>(variableXlsResource, variableXls);
            context.Update(variableXls);
            await context.SaveChangesAsync();
            
            variableXls = await context.VariableXls.FirstOrDefaultAsync(v => v.Id == id);
            var result = mapper.Map<VariableXls, VariableXlsResource>(variableXls);

            return Ok(result);
        }

    }
}