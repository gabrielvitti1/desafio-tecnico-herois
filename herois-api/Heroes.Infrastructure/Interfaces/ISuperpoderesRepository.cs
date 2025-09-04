using Heroes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Infrastructure.Interfaces
{
    public interface ISuperpoderesRepository
    {
        Task<List<SuperpoderEntity>> GetAllSuperpoderes();
    }
}
