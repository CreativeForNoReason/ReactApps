namespace ReactApp.Data.HttpRequests
{
    public class PostInput
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string script { get; set; }
        public string language { get; set; }
        public string versionIndex { get; set; }
    }
}
