using Microsoft.EntityFrameworkCore;
using ReactApp.Models;

namespace ReactApp.Data.Interfaces
{
    public interface ILayeredDbContext
    {
        public Task<IEnumerable<CodeSolution>> GetCodeSolutions();
        public Task SaveCodeSolutions(CodeSolution codeSolution);
    }
}
