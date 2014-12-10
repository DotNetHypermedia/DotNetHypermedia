using System;

namespace DotNetHypermedia.CollectionJson
{
    public abstract class CollectionJsonResourceConverter<TModel> : IResourceConverter<CollectionJsonResourceObject, TModel>
    {
        public Type Converts
        {
            get { return typeof(TModel); }
        }

        public abstract CollectionJsonResourceObject ConvertToResource(TModel model, IRequestContext context);
        public abstract bool CanConvertToResource(IRequestContext context);
        public abstract TModel ConvertFromResource(CollectionJsonResourceObject resource);

        public virtual bool CanConvertFromResource()
        {
            return true;
        }
    }
}
