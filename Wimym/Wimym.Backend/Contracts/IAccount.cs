using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wimym.Backend.Models;
using Wymim.Domain;

namespace Wimym.Backend.Contracts
{
    public interface IAccount : IGenericRepository<Account>
    {
    }
}
