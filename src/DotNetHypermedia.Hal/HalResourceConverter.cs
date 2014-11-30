using System;

namespace DotNetHypermedia.Hal
{
    public abstract class HalResourceConverter<TModel> : IResourceConverter<HalResourceObject, TModel>
    {
        public Type Converts
        {
            get { return typeof (TModel); }
        }

        public abstract HalResourceObject ConvertToResource(TModel model, IRequestContext context);
        public abstract bool CanConvertToResource(IRequestContext context);
        public abstract TModel ConvertFromResource(HalResourceObject resource);

        public virtual bool CanConvertFromResource()
        {
            return true;
        }
    }
}