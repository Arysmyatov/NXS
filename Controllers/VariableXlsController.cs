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


namespace NXS.Controllers
{
    [Route("/api/variablexls")]
    public class VariableXlsController : Controller
    {
        private readonly IVariableXlsRepository _variableXlsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VariableXlsController(IVariableXlsRepository variableXlsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._variableXlsRepository = variableXlsRepository;
            this._unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetVariableXls(VariableXlsQueryResource filterResource)
        {
            var variableXls =  _variableXlsRepository.GetVariableXlsAsync(filterResource.VariableId.Value);

            if (variableXls == null)
                return NotFound();

            var variableResource = _mapper.Map<VariableXls, VariableXlsResource>(variableXls);

            return Ok(variableResource);
        }


        [HttpPost]
        public async Task<IActionResult> CreateVariableXls([FromBody] SaveVariableXlsResource variableXlsResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var variableXls = _mapper.Map<SaveVariableXlsResource, VariableXls>(variableXlsResource);

            _variableXlsRepository.Add(variableXls);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<VariableXls, VariableXlsResource>(variableXls);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVariable(int id, [FromBody] SaveVariableXlsResource variableXlsResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var variableXls = _mapper.Map<SaveVariableXlsResource, VariableXls>(variableXlsResource);

            _variableXlsRepository.Update(variableXls);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<VariableXls, VariableXlsResource>(variableXls);

            return Ok(result);
        }

    }
}