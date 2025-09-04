using Heroes.Application.DTOs;
using Heroes.Application.Shared;
using Heroes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Application.Interfaces
{
    public interface ISuperpoderesService
    {
        Task<ResultPattern<List<GetSuperpoderesResponse>>> GetAllSuperpoderes();
    }

}
