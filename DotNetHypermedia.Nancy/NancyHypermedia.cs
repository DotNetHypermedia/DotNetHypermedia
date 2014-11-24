using Nancy.Bootstrapper;

namespace DotNetHypermedia.Nancy
{
    public static class NancyHypermedia
    {
        public static NancyInternalConfiguration RegisterHypermediaSupport(this NancyInternalConfiguration configuration)
        {
            DotHypermediaContext.CurrentHost = new NancyHost(configuration);
            configuration.ResponseProcessors.Add(typeof(JsonHalProcessor));
            return configuration;
        }
    }
}