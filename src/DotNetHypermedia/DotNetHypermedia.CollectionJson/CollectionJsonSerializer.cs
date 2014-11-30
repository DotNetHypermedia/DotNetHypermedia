using System;
using System.IO;

namespace DotNetHypermedia.CollectionJson
{
    public class CollectionJsonSerializer : IResourceSerializer<CollectionJsonResourceObject>
    {
        public void Serialize(TextWriter writer, CollectionJsonResourceObject resource)
        {
            throw new NotImplementedException();
        }

        public CollectionJsonResourceObject Deserialize(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public string MediaType
        {
            get { return "application/vnd.collection+json"; }
        }
    }
}
