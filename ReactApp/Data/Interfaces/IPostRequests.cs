using ReactApp.Data.HttpRequests;

namespace ReactApp.Data.Interfaces
{
    public interface IPostRequests
    {
        Task<PostResponse> GetResponseFromPostRequest(string codeSolution);
    }
}
