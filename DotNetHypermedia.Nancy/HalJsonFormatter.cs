using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Responses.Negotiation;

namespace DotNetHypermedia.Nancy
{
    public class JsonHalProcessor : IResponseProcessor
    {
        private const string HalJsonMediaType = "application/hal+json";

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            if (requestedMediaRange.Type.Matches(new MediaType(HalJsonMediaType)))
                return new ProcessorMatch
                {
                    ModelResult = MatchResult.DontCare,
                    RequestedContentTypeResult = MatchResult.ExactMatch
                };

            return new ProcessorMatch();
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return new Response
            {
                ContentType = HalJsonMediaType,
                Contents = stream => JsonHalSerializer.SerializeTo(model, stream),
                StatusCode = HttpStatusCode.OK
            };
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { return Enumerable.Empty<Tuple<string, MediaRange>>(); }
        }
    }
}
