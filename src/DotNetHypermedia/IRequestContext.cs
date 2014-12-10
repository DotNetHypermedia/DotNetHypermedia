namespace DotNetHypermedia
{
    /// <summary>
    /// A platform agnostic, mockable, abstraction of a request
    /// </summary>
    public interface IRequestContext
    {
        // TODO: Could we borrow this abstraction from OWIN?

        string Accepts { get; set; }
    }
}