using Heroes.Domain.Entities;
using Heroes.Infrastructure.Interfaces;
using Heroes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Infrastructure.Repositories
{
    public class HeroesRepository(HeroesContext context) : IHeroesRepository
    {
        public async Task<List<HeroiEntity>> GetAllHerois()
        {
            return await context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoder)
                .ToListAsync();
        }
        public async Task<HeroiEntity> GetHeroiByIdAsync(int id)
        {
            return await context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoder)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<bool> HasAnyWithNomeHeroi(String nomeHeroi) =>
            await context.Herois.AnyAsync(h => h.NomeHeroi == nomeHeroi);

        public async Task InsertHeroi(HeroiEntity heroi)
        {
            await context.Herois.AddAsync(heroi);
            await context.SaveChangesAsync();
        }

        public async Task<HeroiEntity> PatchHeroi(
            int idHeroi,
            string? nome,
            string? nomeHeroi,
            DateTime? dataNascimento,
            float? altura,
            float? peso,
            List<int>? superpoderesIds)
        {
            HeroiEntity heroi = await GetHeroiByIdAsync(idHeroi);

            if (!string.IsNullOrWhiteSpace(nome))
                heroi.Nome = nome;

            if (!string.IsNullOrWhiteSpace(nomeHeroi))
                heroi.NomeHeroi = nomeHeroi;

            if (dataNascimento.HasValue)
                heroi.DataNascimento = dataNascimento;

            if (altura.HasValue)
                heroi.Altura = altura.Value;

            if (peso.HasValue)
                heroi.Peso = peso.Value;

            if (superpoderesIds != null)
            {
                heroi.HeroisSuperpoderes.Clear();

                foreach (int idPoder in superpoderesIds)
                    heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderesEntity { SuperpoderId = idPoder });
            }

            await context.SaveChangesAsync();
            return heroi;
        }

        public async Task DeleteHeroi(int idHeroi)
        {
            HeroiEntity heroi = await GetHeroiByIdAsync(idHeroi);
            context.Herois.Remove(heroi);
            await context.SaveChangesAsync();
        }
    }
}
