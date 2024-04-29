using MayTheFourth.Application.Features.Films;
using MayTheFourth.Application.Features.Films.GetFilmes;
using MayTheFourth.Application.Features.Planets;
using MayTheFourth.Application.Features.Planets.GetPlanetById;
using MayTheFourth.Application.Planets.GetPlanetById.GetPlanet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class PlanetsEndpoints
    {
        //TODO - Adicionar Endpoints
        public static void MapPlanetsEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/planetas")
                .WithTags("Planetas")
                .WithOpenApi();

            root.MapGet("/", GetPlanetasAsync)
                .Produces<List<GetPlanetResponse>>()
                .WithSummary("Obtem todos os planetas cadastrados")
                .WithDescription("Endpoint para leitura e retorno da lista de planetas cadastrados");

            root.MapGet("/{id}", GetPlanetasByIdAsync)
                .Produces<GetPlanetResponse>()
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Obtem um planeta cadastrado")
                .WithDescription("Endpoint para leitura e retorno de um filme cadastrado pelo Id correspondente");
        }

        //TODO - Adicionar métodos
        private static async Task<IResult> GetPlanetasAsync
        (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            var result = await mediator.Send(new GetPlanetRequest(), cancellationToken);

            return Results.Ok(result);
        }

        private static async Task<IResult> GetPlanetasByIdAsync
        (
           [FromRoute] int id,
           [FromServices] IMediator mediator
        )
        {
            var result = await mediator.Send(new GetPlanetByIdRequest(id));

            if (result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }
    }
}
