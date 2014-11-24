using System.Collections.Generic;

namespace DotNetHypermedia
{
    public class HypermediaStore
    {
        private readonly Dictionary<object, List<Link>> links = new Dictionary<object, List<Link>>();

        public void AddHypermediaLink(object @ref, Link link)
        {
            if (!links.ContainsKey(@ref))
                links.Add(@ref, new List<Link>());
            links[@ref].Add(link);
        }

        public IEnumerable<Link> LinksFor(object @ref)
        {
            return links[@ref];
        } 
    }
}
