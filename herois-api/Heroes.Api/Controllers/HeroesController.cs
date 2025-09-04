using Heroes.Application.DTOs;
using Heroes.Application.Interfaces;
using Heroes.Application.Shared;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HeroesController(IHeroesService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostHero(CreateHeroiRequest request)
    {
        ResultPattern resultado = await service.PostHeroi(request);

        if (!resultado.IsSuccess)
            return StatusCode(StatusCodes.Status400BadRequest, resultado.Error);

        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet]
    public async Task<IActionResult> GetHeroes()
    {
        ResultPattern<List<GetHeroiResponse>> resultado = await service.GetHerois();

        if (!resultado.IsSuccess)
            return StatusCode(StatusCodes.Status404NotFound, resultado.Error);

        return StatusCode(StatusCodes.Status200OK, resultado.Value);
    }

    [HttpGet("{idHeroi}")]
    public async Task<IActionResult> GetHeroiById([FromRoute] int idHeroi)
    {
        if (idHeroi <= 0)
            return StatusCode(StatusCodes.Status400BadRequest, "Id do herói inválido");

        ResultPattern<GetHeroiResponse> resultado = await service.GetHeroiById(idHeroi);

        if (!resultado.IsSuccess)
            return StatusCode(StatusCodes.Status404NotFound, resultado.Error);

        return StatusCode(StatusCodes.Status200OK, resultado.Value);
    }

    [HttpPatch("{idHeroi}")]
    public async Task<IActionResult> PatchHeroi([FromRoute] int idHeroi, [FromBody] PatchHeroiRequest request)
    {
        if(idHeroi <= 0)
            return StatusCode(StatusCodes.Status400BadRequest, "Id do herói inválido");

        ResultPattern<PatchHeroiResponse> resultado = await service.PatchHeroi(idHeroi, request);

        if (!resultado.IsSuccess)
            return StatusCode(StatusCodes.Status404NotFound, resultado.Error);

        return StatusCode(StatusCodes.Status200OK, resultado);
    }

    [HttpDelete("{idHeroi}")]
    public async Task<IActionResult> DeleteHeroi([FromRoute] int idHeroi)
    {
        if (idHeroi <= 0)
            return StatusCode(StatusCodes.Status400BadRequest, "Id do herói inválido");

        ResultPattern resultado = await service.DeleteHeroi(idHeroi);

        if (!resultado.IsSuccess)
            return StatusCode(StatusCodes.Status404NotFound, resultado.Error);

        return StatusCode(StatusCodes.Status200OK, "Herói excluído com sucesso");
    }
}
