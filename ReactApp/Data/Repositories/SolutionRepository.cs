using Microsoft.EntityFrameworkCore;
using ReactApp.Data.HttpRequests;
using ReactApp.Data.Interfaces;
using ReactApp.Models;

namespace ReactApp.Data.Repositories
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly ILayeredDbContext _context;
        private readonly IPostRequests _postRequests;

        public SolutionRepository(ILayeredDbContext context, IPostRequests postRequests)
        {
            _context = context;
            _postRequests = postRequests;
        }

        public async Task<IEnumerable<CodeSolution>> GetCodeSolutions()
        {
            return await _context.GetCodeSolutions();
        }

        public async Task<CodeSolution> PostCodeSolution(CodeSolution codeSolution)
        {
            var result = await _postRequests.GetResponseFromPostRequest(codeSolution.SolutionCode);

            if (result.statusCode != 200 || result.output == null)
            {
                return null;
            }

            codeSolution.Result = result.output;
            await _context.SaveCodeSolutions(codeSolution);

            return codeSolution;
        }
    }
}
