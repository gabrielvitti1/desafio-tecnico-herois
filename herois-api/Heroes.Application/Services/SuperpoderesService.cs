using Heroes.Application.DTOs;
using Heroes.Domain.Entities;
using Heroes.Infrastructure.Interfaces;
using Heroes.Application.Shared;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.Application.Interfaces;

namespace Heroes.Application.Services
{
    public class SuperpoderesService(ISuperpoderesRepository repository) : ISuperpoderesService
    {
        public async Task<ResultPattern<List<GetSuperpoderesResponse>>> GetAllSuperpoderes()
        {
            List<SuperpoderEntity> superpoderes = await repository.GetAllSuperpoderes();

            List<GetSuperpoderesResponse> response = superpoderes.Select(x => new GetSuperpoderesResponse
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Superpoder = x.Superpoder,
            }).ToList();

            if (response.Count == 0)
                return ResultPattern<List<GetSuperpoderesResponse>>.Failure("A lista de superpoderes está vazia");

            return ResultPattern<List<GetSuperpoderesResponse>>.Success(response);
        }
    }
}
