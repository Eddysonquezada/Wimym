using System;
using System.Collections.Generic;
using System.Text;
using Wymim.Common;

namespace Wymim.Common.Interfaces
{
    public interface ICurrentUserFactory
    {
        CurrentUser Get { get; }
    }
}
