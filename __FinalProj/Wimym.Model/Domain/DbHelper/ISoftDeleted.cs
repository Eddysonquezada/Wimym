using System;
using System.Collections.Generic;
using System.Text;

namespace Wimym.Model.Domain.DbHelper
{
    public interface ISoftDeleted
    {
        bool Deleted { get; set; }
    }
}
