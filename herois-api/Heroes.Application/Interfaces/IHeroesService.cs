using Heroes.Application.DTOs;
using Heroes.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Application.Interfaces
{
    public interface IHeroesService
    {
        Task<ResultPattern> PostHeroi(CreateHeroiRequest request);
        Task<ResultPattern<List<GetHeroiResponse>>> GetHerois();
        Task<ResultPattern<GetHeroiResponse>> GetHeroiById(int idHeroi);
        Task<ResultPattern<PatchHeroiResponse>> PatchHeroi(int idHeroi, PatchHeroiRequest request);
        Task<ResultPattern> DeleteHeroi(int idHeroi);
    }
}
