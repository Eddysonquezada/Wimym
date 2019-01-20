using System;
using System.Collections.Generic;
using System.Text;

namespace Wymim.Domain.Helper
{
    public interface ISoftDeleted
    {
        bool Deleted { get; set; }
    }
}
