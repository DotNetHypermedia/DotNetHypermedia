using System;
using System.Collections.Generic;
using System.IO;
using Nancy;

namespace DotNetHypermedia.Nancy
{
    // TODO: How to get the request context here?

    public class DotNetHypermediaSerializer : ISerializer
    {
        public bool CanSerialize(string contentType)
        {
            throw new NotImplementedException();
        }

        public void Serialize<TModel>(string contentType, TModel model, Stream outputStream)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Extensions { get; private set; }
    }
}
