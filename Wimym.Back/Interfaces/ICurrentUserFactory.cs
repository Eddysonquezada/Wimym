using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wimym.Back.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wymim.Common;

    public interface ICurrentUserFactory
    {
        CurrentUser Get { get; }
    }
}
