using System.Web.Http;

namespace DotNetHypermedia.WebApi
{
    public static class WebApiHypermedia
    {
        public static HttpConfiguration RegisterHypermediaSupport(this HttpConfiguration configuration)
        {
            DotHypermediaContext.CurrentHost = new WebApiHost(configuration);
            configuration.Formatters.Add(new JsonHalMediaTypeFormatter());
            return configuration;
        } 
    }
}