using Microsoft.EntityFrameworkCore;
using ReactApp.Data.Interfaces;
using ReactApp.Models;

namespace ReactApp.Data
{
    public class LayeredDbContext : ILayeredDbContext
    {
        private readonly ApplicationDbContext _context;

        public LayeredDbContext(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CodeSolution>> GetCodeSolutions()
        {
            return await _context.CodeSolution.ToListAsync();
        }

        public async Task SaveCodeSolutions(CodeSolution codeSolution)
        {
            _context.Add(codeSolution);
            await _context.SaveChangesAsync();
        }
    }
}
