using System.Web.Http;

namespace DotNetHypermedia.WebApi
{
    public class WebApiHost : IHost
    {
        private readonly HttpConfiguration _configuration;

        public WebApiHost(HttpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HypermediaStore GetOrCreateRequestHypermediaStore()
        {
            // TODO Not sure how to do this off the top of my head with web api.. Need the googles
        }
    }
}