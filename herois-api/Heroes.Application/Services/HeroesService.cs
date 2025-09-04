using Heroes.Application.DTOs;
using Heroes.Application.Interfaces;
using Heroes.Application.Shared;
using Heroes.Domain.Entities;
using Heroes.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Application.Services
{
    public class HeroesService(IHeroesRepository heroesRepository, ISuperpoderesRepository superpoderesRepository) : IHeroesService
    {
        public async Task<ResultPattern> PostHeroi(CreateHeroiRequest request)
        {
            List<SuperpoderEntity> superpoderesValidos = await superpoderesRepository.GetAllSuperpoderes();

            request.SuperpoderesIds = request.SuperpoderesIds.Distinct().ToList(); // Evitar valores duplicados

            List<int> superpoderesIdsValidos = superpoderesValidos.Select(s => s.Id).ToList();

            List<int> idsInvalidos = request.SuperpoderesIds.Except(superpoderesIdsValidos).ToList();
            if (idsInvalidos.Any())
                return ResultPattern.Failure($"Os seguintes IDs de superpoderes são inválidos: {string.Join(", ", idsInvalidos)}");

            if (await heroesRepository.HasAnyWithNomeHeroi(request.NomeHeroi))
                return ResultPattern.Failure($"Já existe um herói com esse nome: {request.NomeHeroi}");

            await heroesRepository.InsertHeroi(new HeroiEntity
            {
                Nome = request.Nome,
                NomeHeroi = request.NomeHeroi,
                DataNascimento = request.DataNascimento,
                Altura = request.Altura,
                Peso = request.Peso,
                HeroisSuperpoderes = request.SuperpoderesIds.Select(id => new HeroisSuperpoderesEntity
                {
                    SuperpoderId = id
                }).ToList()
            });

            return ResultPattern.Success();
        }

        public async Task<ResultPattern<List<GetHeroiResponse>>> GetHerois()
        {
            List<HeroiEntity> herois = await heroesRepository.GetAllHerois();
            if (herois.Count == 0)
                return ResultPattern<List<GetHeroiResponse>>.Failure("A lista de heróis está vazia");

            List<GetHeroiResponse> response = herois.Select(h => new GetHeroiResponse
            {
                Id = h.Id,
                Nome = h.Nome,
                NomeHeroi = h.NomeHeroi,
                DataNascimento = h.DataNascimento,
                Altura = h.Altura,
                Peso = h.Peso,
                Superpoderes = h.HeroisSuperpoderes.Select(hs => new GetSuperpoderesResponse
                {
                    Id = hs.Superpoder.Id,
                    Superpoder = hs.Superpoder.Superpoder,
                    Descricao = hs.Superpoder.Descricao
                }).ToList()
            }).ToList();

            return ResultPattern<List<GetHeroiResponse>>.Success(response);
        }

        public async Task<ResultPattern<GetHeroiResponse>> GetHeroiById(int idHeroi)
        {
            HeroiEntity? heroi = await heroesRepository.GetHeroiByIdAsync(idHeroi);
            if (heroi == null)
                return ResultPattern<GetHeroiResponse>.Failure("Herói não encontrado");

            GetHeroiResponse response = new GetHeroiResponse
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.HeroisSuperpoderes.Select(hs => new GetSuperpoderesResponse
                {
                    Id = hs.Superpoder.Id,
                    Superpoder = hs.Superpoder.Superpoder,
                    Descricao = hs.Superpoder.Descricao
                }).ToList()
            };

            return ResultPattern<GetHeroiResponse>.Success(response);
        }

        public async Task<ResultPattern<PatchHeroiResponse>> PatchHeroi(int idHeroi, PatchHeroiRequest request)
        {
            HeroiEntity? heroi = await heroesRepository.GetHeroiByIdAsync(idHeroi);
            if (heroi == null)
                return ResultPattern<PatchHeroiResponse>.Failure("Herói não encontrado");

            if (!String.IsNullOrWhiteSpace(request.NomeHeroi))
            {
                if (await heroesRepository.HasAnyWithNomeHeroi(request.NomeHeroi))
                    return ResultPattern<PatchHeroiResponse>.Failure($"Já existe um herói com esse nome: {request.NomeHeroi}");
            }

            if (request.SuperpoderesIds != null)
            {
                request.SuperpoderesIds = request.SuperpoderesIds.Distinct().ToList(); //Evitar valores duplicados

                List<SuperpoderEntity> superpoderesValidos = await superpoderesRepository.GetAllSuperpoderes();

                List<int> superpoderesIdsValidos = superpoderesValidos.Select(s => s.Id).ToList();

                List<int> idsInvalidos = request.SuperpoderesIds.Except(superpoderesIdsValidos).ToList();
                if (idsInvalidos.Any())
                    return ResultPattern<PatchHeroiResponse>.Failure($"Os seguintes IDs de superpoderes são inválidos: {string.Join(", ", idsInvalidos)}");
            }

            HeroiEntity heroiAtualizado = await heroesRepository.PatchHeroi(
                idHeroi,
                request.Nome,
                request.NomeHeroi,
                request.DataNascimento,
                request.Altura,
                request.Peso,
                request.SuperpoderesIds);

            PatchHeroiResponse response = new PatchHeroiResponse
            {
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.HeroisSuperpoderes.Select(hs => new GetSuperpoderesResponse
                {
                    Id = hs.Superpoder.Id,
                    Superpoder = hs.Superpoder.Superpoder,
                    Descricao = hs.Superpoder.Descricao
                }).ToList()
            };

            return ResultPattern<PatchHeroiResponse>.Success(response);
        }

        public async Task<ResultPattern> DeleteHeroi(int idHeroi)
        {
            HeroiEntity? heroi = await heroesRepository.GetHeroiByIdAsync(idHeroi);
            if (heroi == null)
                return ResultPattern.Failure("Herói não encontrado");

            await heroesRepository.DeleteHeroi(idHeroi);
            return ResultPattern.Success();
        }
    }
}