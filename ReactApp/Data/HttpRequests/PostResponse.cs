namespace ReactApp.Data.HttpRequests
{
    public class PostResponse
    {
        public string output { get; set; }
        public int statusCode { get; set; }
        public int? memory { get; set; }
        public double? cpuTime { get; set; }
    }
}
