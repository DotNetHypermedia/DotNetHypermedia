using System;
using System.IO;

namespace DotNetHypermedia.Hal
{
    public class HalXmlSerializer : IResourceSerializer<HalResourceObject>
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
            get { return "application/hal+xml"; }
        }
    }
}