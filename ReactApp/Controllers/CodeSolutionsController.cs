using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactApp.Data;
using ReactApp.Data.Interfaces;
using ReactApp.Data.Repositories;
using ReactApp.Models;

namespace ReactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeSolutionsController : ControllerBase
    {
        private readonly ISolutionRepository _solutionRepository;

        public CodeSolutionsController(ISolutionRepository solutionRepository)
        {
            _solutionRepository = solutionRepository;
        }

        // GET: api/CodeSolutions
        [HttpGet]
        public async Task<IEnumerable<CodeSolution>> GetCodeSolutions()
        {
            return await _solutionRepository.GetCodeSolutions(); 
        }  

        // POST: api/CodeSolutions
        [HttpPost]
        public async Task<ActionResult<CodeSolution>> PostCodeSolution(CodeSolution codeSolution)
        {
            var newSolution = await _solutionRepository.PostCodeSolution(codeSolution);

            if (newSolution == null)
            {
                return Problem("Invalid response form compiler api");
            }

            return CreatedAtAction(nameof(GetCodeSolutions), new { id = newSolution.Id }, newSolution);
        }    
    }
}
