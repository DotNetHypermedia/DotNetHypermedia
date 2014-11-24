namespace DotNetHypermedia
{
    public static class HypermediaExtensions
    {
        public static void AddHypermediaLink(this object representation, Link link)
        {
            var store = DotHypermediaContext.CurrentHost.GetOrCreateRequestHypermediaStore();
            store.AddHypermediaLink(representation, link);
        }
    }
}