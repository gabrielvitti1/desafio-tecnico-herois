using Heroes.Application.DTOs;
using Heroes.Application.Interfaces;
using Heroes.Application.Services;
using Heroes.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController(ISuperpoderesService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSuperpoderes()
        {
            ResultPattern<List<GetSuperpoderesResponse>> resultado = await service.GetAllSuperpoderes();

            if (!resultado.IsSuccess)
                return StatusCode(StatusCodes.Status404NotFound, resultado.Error);

            return StatusCode(StatusCodes.Status200OK, resultado.Value);
        }
    }
}
