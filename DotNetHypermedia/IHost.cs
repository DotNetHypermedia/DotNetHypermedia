using System;

namespace DotNetHypermedia
{
    public interface IHost
    {
        /// <summary>
        /// Gets or creates a new HypermediaStore for the current http request
        /// </summary>
        HypermediaStore GetOrCreateRequestHypermediaStore();
    }
}