namespace Wimym.Web.Interfaces
{
    using Wimym.Web.Helpers;
    public interface ICurrentUserFactory
    {
        CurrentUser Get { get; }
    }
}
