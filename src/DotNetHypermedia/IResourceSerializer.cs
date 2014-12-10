using System.IO;

namespace DotNetHypermedia
{
    /// <summary>
    /// Serializer for resource objects
    /// </summary>
    /// <typeparam name="TResource">Resource to be serialized</typeparam>
    public interface IResourceSerializer<TResource> where TResource : IResource
    {
        /// <summary>
        /// Serializes the resource
        /// </summary>
        /// <param name="writer">Destination for the serialized result</param>
        /// <param name="resource">Resource to serialize</param>
        /// <returns>Serialized resource</returns>
        void Serialize(TextWriter writer, TResource resource);

        /// <summary>
        /// Deserialized the resource
        /// </summary>
        /// <param name="reader">Source for the deserializer</param>
        /// <returns>Deserialized resource</returns>
        TResource Deserialize(TextReader reader);

        /// <summary>
        /// Gets the media type format this serializer supports
        /// </summary>
        string MediaType { get; }
    }
}
