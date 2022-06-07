using ReactApp.Models;

namespace ReactApp.Data.Repositories
{
    public interface ISolutionRepository
    {
        public Task<IEnumerable<CodeSolution>> GetCodeSolutions();
        public Task<CodeSolution> PostCodeSolution(CodeSolution codeSolution);
    }
}
