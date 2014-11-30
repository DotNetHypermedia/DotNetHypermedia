using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetHypermedia.WebApi
{
    public class HypermediaDotNetMediaTypeFormatter : MediaTypeFormatter
    {
        private static readonly ICollection<IFormatter> Formatters = new List<IFormatter>();

        private readonly IRequestContext _context;
        private readonly IFormatter _formatter;
        private readonly bool _hasContext;

        public HypermediaDotNetMediaTypeFormatter(IEnumerable<IFormatter> formatters)
        {
            if (formatters == null) 
                throw new ArgumentNullException("formatters");

            foreach (var formatter in formatters)
            {
                if (!Formatters.Any(x => x.MediaType.Equals(formatter.MediaType, StringComparison.OrdinalIgnoreCase)))
                    throw new ArgumentException("Multiple formatters detected for media type: " + formatter.MediaType);

                Formatters.Add(formatter);
            }
        }

        private HypermediaDotNetMediaTypeFormatter(IRequestContext context, IFormatter formatter)
        {
            _context = context;
            _formatter = formatter;
            _hasContext = true;
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            var formatter = Formatters.FirstOrDefault(x => x.MediaType.Equals(mediaType.MediaType, StringComparison.OrdinalIgnoreCase));
            var context = request.ToRequestContext();

            return new HypermediaDotNetMediaTypeFormatter(context, formatter);
        }

        public override bool CanReadType(Type type)
        {
            return _hasContext && _formatter.CanRead(type);
        }

        public override bool CanWriteType(Type type)
        {
            return _hasContext && _formatter.CanWrite(type, _context);
        }

        public override Task<object> ReadFromStreamAsync(
            Type type,
            Stream readStream,
            HttpContent content,
            IFormatterLogger formatterLogger,
            CancellationToken cancellationToken)
        {
            if (!_hasContext)
                throw new InvalidOperationException("Formatter has no context and thus cannot write.");

            return Task<object>.Factory.StartNew(() => _formatter.ReadFromStream(type, readStream), cancellationToken);
        }

        public override Task WriteToStreamAsync(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content,
            TransportContext transportContext,
            CancellationToken cancellationToken)
        {
            if (!_hasContext)
                throw new InvalidOperationException("Formatter has no context and thus cannot read.");

            return Task.Factory.StartNew(() => _formatter.WriteToStream(value, _context, writeStream), cancellationToken);
        }
    }
}
