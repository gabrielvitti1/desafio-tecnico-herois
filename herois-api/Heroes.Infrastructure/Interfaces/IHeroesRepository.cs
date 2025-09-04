using Heroes.Domain.Entities;

namespace Heroes.Infrastructure.Interfaces
{
    public interface IHeroesRepository
    {
        Task<List<HeroiEntity>> GetAllHerois();
        Task<HeroiEntity> GetHeroiByIdAsync(int id);
        Task<bool> HasAnyWithNomeHeroi(string nomeHeroi);
        Task InsertHeroi(HeroiEntity heroi);
        Task<HeroiEntity> PatchHeroi(
            int idHeroi,
            string? nome,
            string? nomeHeroi,
            DateTime? dataNascimento,
            float? altura,
            float? peso,
            List<int>? superpoderesIds);

        Task DeleteHeroi(int idHeroi);
    }
}