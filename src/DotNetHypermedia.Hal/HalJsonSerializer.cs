using System;
using System.IO;

namespace DotNetHypermedia.Hal
{
    public class HalJsonSerializer : IResourceSerializer<HalResourceObject>
    {
        public void Serialize(TextWriter writer, HalResourceObject resource)
        {
            throw new NotImplementedException();
        }

        public HalResourceObject Deserialize(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public string MediaType
        {
            get { return "application/hal+json"; }
        }
    }
}