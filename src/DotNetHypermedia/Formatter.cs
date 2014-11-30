using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DotNetHypermedia
{
    public class Formatter<TResource> : IFormatter
        where TResource : IResource
    {
        private readonly IEnumerable<IResourceConverter> _converters;
        private readonly IResourceSerializer<TResource> _serializer;

        protected Formatter(IEnumerable<IResourceConverter> converters, IResourceSerializer<TResource> serializer)
        {
            if (converters == null)
                throw new ArgumentNullException("converters");

            if (serializer == null)
                throw new ArgumentNullException("serializer");

            _converters = converters;
            _serializer = serializer;
        }

        public void WriteToStream(object model, IRequestContext context, Stream stream)
        {
            var modelType = model.GetType();
            var method = GetType().GetMethod("Write", BindingFlags.Instance | BindingFlags.NonPublic);
            var generic = method.MakeGenericMethod(modelType);

            generic.Invoke(this, new object[] {model, context, stream});
        }

        /// <summary>
        /// Called through reflection, so that we can use generics, rather than objects
        /// </summary>
// ReSharper disable once UnusedMember.Local        
        private void Write<TModel>(TModel model, IRequestContext context, Stream stream)
        {
            var converter = (IResourceConverter<TResource, TModel>) _converters.Single(x => x.Converts == model.GetType());
            var resource = converter.ConvertToResource(model, context);

            using (var writer = new StreamWriter(stream))
                _serializer.Serialize(writer, resource);
        }

        public bool CanWrite(Type modelType, IRequestContext context)
        {
            var converter = _converters.SingleOrDefault(x => x.Converts == modelType);

            return (converter != null) && converter.CanConvertToResource(context);
        }

        public object ReadFromStream(Type modelType, Stream stream)
        {
            var method = GetType().GetMethod("Read", BindingFlags.Instance | BindingFlags.NonPublic);
            var generic = method.MakeGenericMethod(modelType);

            return generic.Invoke(this, new object[] { modelType, stream });
        }

        /// <summary>
        /// Called through reflection, so that we can use generics, rather than objects
        /// </summary>
// ReSharper disable once UnusedMember.Local
        private TModel Read<TModel>(Type modelType, Stream stream)
        {
            var converter = (IResourceConverter<TResource, TModel>) _converters.Single(x => x.Converts == modelType);

            using (var reader = new StreamReader(stream))
            {
                var resource = _serializer.Deserialize(reader);

                return converter.ConvertFromResource(resource);
            }
        }

        public bool CanRead(Type modelType)
        {
            var converter = _converters.SingleOrDefault(x => x.Converts == modelType);

            return (converter != null) && converter.CanConvertFromResource();
        }

        public string MediaType
        {
            get { return _serializer.MediaType; }
        }
    }
}