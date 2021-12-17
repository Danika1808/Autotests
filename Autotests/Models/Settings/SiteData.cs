namespace Autotests.Models.Settings
{
    public class SiteData
    {
        public string BaseUrl { get; set; }
        public string MainPageUrl => BaseUrl + "/";

        public SiteData()
        {
        }

        public SiteData(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}