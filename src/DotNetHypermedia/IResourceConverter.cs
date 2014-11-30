using System;

namespace DotNetHypermedia
{
    public interface IResourceConverter
    {
        /// <summary>
        /// Type this converter can convert to/from
        /// </summary>
        Type Converts { get; }

        /// <summary>
        /// Determines whether a resource can be converted to a model
        /// </summary>
        /// <returns>True if conversion is possible</returns>
        bool CanConvertFromResource();

        /// <summary>
        /// Determines whether a model can be converted to a resource, given the current request context
        /// </summary>
        /// <param name="context">Context of the conversion</param>
        /// <returns>True if conversion is possible</returns>
        bool CanConvertToResource(IRequestContext context);
    }

    public interface IResourceConverter<TResource, TModel> : IResourceConverter where TResource : IResource
    {
        /// <summary>
        /// Converts the <see cref="TModel"/> instance into a <see cref="TResource"/> instance
        /// </summary>
        /// <param name="model">The <see cref="TModel"/> instance to be converted</param>
        /// <param name="context">Context of the conversion</param>
        /// <returns>A <see cref="TResource"/> instance representation of the <see cref="TModel"/> instance</returns>
        TResource ConvertToResource(TModel model, IRequestContext context);

        /// <summary>
        /// Converts the <see cref="TResource"/> instance into a <see cref="TModel"/> instance
        /// </summary>
        /// <param name="resource">Resource to convert</param>
        /// <returns>A <see cref="TModel"/> instance extracted from the <see cref="TResource"/> instance</returns>
        TModel ConvertFromResource(TResource resource);
    }
}