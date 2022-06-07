using Newtonsoft.Json;
using ReactApp.Data.Interfaces;
using System.Text;

namespace ReactApp.Data.HttpRequests
{
    public class PostRequestJdoodleMaker : IPostRequests
    {
        private const string URL = "https://api.jdoodle.com/v1/execute";
        private PostInput? _input;

        public PostRequestJdoodleMaker()
        {
            _input = new PostInput()
            {
                clientId = "73c33d84fab03490620f56b2a53e68d0",
                clientSecret = "d432ba0c51590327da431e899458ab959a42d92f7da85fd2dde144cf93759492",
                language = "csharp",
                versionIndex = "4"
            };
        }

        public async Task<PostResponse> GetResponseFromPostRequest(string codeSolution)
        {
            _input.script = codeSolution;
            var json = JsonConvert.SerializeObject(_input);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(URL, data);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PostResponse>(result);
            }
        }
    }
}
