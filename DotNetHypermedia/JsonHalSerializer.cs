using System.IO;

namespace DotNetHypermedia
{
    public class JsonHalSerializer
    {
        public static void SerializeTo(object model, Stream targetStream)
        {
            var store = DotHypermediaContext.CurrentHost.GetOrCreateRequestHypermediaStore();

            var modelHypermedia = store.LinksFor(model);
            // TODO needs to serialise the model and inject hypermedia for complex object hanging off the model we are serialising
        }
    }
}