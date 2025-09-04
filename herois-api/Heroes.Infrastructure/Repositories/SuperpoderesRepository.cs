using Heroes.Domain.Entities;
using Heroes.Infrastructure.Interfaces;
using Heroes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Infrastructure.Repositories
{
    public class SuperpoderesRepository(HeroesContext context) : ISuperpoderesRepository
    {
        public async Task<List<SuperpoderEntity>> GetAllSuperpoderes() =>
            await context.Superpoderes.ToListAsync();
    }
}
