using System;
using System.IO;
using Nancy.ModelBinding;

namespace DotNetHypermedia.Nancy
{
    public class DotNetHypermediaBodyDeserializer : IBodyDeserializer
    {
        public bool CanDeserialize(string contentType, BindingContext context)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(string contentType, Stream bodyStream, BindingContext context)
        {
            throw new NotImplementedException();
        }
    }
}