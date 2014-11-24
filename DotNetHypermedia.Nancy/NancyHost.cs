using Nancy.Bootstrapper;

namespace DotNetHypermedia.Nancy
{
    public class NancyHost : IHost
    {
        public NancyHost(NancyInternalConfiguration configuration)
        {
            
        }

        public HypermediaStore GetOrCreateRequestHypermediaStore()
        {
            // TODO not sure how to do this for Nancy. 
            // It needs to lookup current request, and check to see if a HypermediaStore has been created
            // If it hasn't, create one and store it in the current requests state
            throw new System.NotImplementedException();
        }
    }
}