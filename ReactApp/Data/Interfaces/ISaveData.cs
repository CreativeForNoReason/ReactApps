using ReactApp.Models;

namespace ReactApp.Data.Interfaces
{
    public interface ISaveData
    {
        Task SaveDataAsync(CodeSolution codeSolution);
    }
}
