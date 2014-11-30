using System;
using System.IO;

namespace DotNetHypermedia
{
    /// <summary>
    /// Media type specific formatter that can read from, and write to, a stream.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Formats the passed in object and writers it to the specified stream
        /// </summary>
        /// <param name="model">Model to be formatted</param>
        /// <param name="context">Context of the request that triggers the formatting</param>
        /// <param name="stream">Stream to write to</param>
        void WriteToStream(object model, IRequestContext context, Stream stream);

        /// <summary>
        /// Determines whether objects of the specified in type can be written.
        /// </summary>
        /// <param name="modelType">Type of the model to write</param>
        /// <param name="context">Context of the request that triggers the formatting</param>
        /// <returns>True if the model can be written</returns>
        bool CanWrite(Type modelType, IRequestContext context);

        /// <summary>
        /// Reads a formatted representation of the specified model type from the specified stream
        /// </summary>
        /// <param name="modelType">Type of the model to be read</param>
        /// <param name="stream"></param>
        /// <returns>An instance of the specified model type</returns>
        object ReadFromStream(Type modelType, Stream stream);

        /// <summary>
        /// Determines whether objects of the specified in type can be read.
        /// </summary>
        /// <param name="modelType">Type of the model to read</param>
        /// <returns>True if the model can be read</returns>
        bool CanRead(Type modelType);
        
        /// <summary>
        /// The mediatype supported by this formatter
        /// </summary>
        string MediaType { get; }
    }
}