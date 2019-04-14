using Wimym.Web.Helpers;

namespace Wimym.Web.Interfaces
{
    public interface ICurrentUserFactory
    {
        CurrentUser Get { get; }
    }
}
