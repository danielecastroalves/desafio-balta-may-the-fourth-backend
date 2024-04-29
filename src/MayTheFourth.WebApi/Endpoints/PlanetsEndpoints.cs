using MayTheFourth.Application.Features.Planets;
using MayTheFourth.Application.Features.Planets.GetPlanetById;
using MayTheFourth.Application.Features.Planets.GetPlanetRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class PlanetsEndpoints
    {
        public static void MapPlanetsEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/planets")
                .WithTags("Planets")
                .WithOpenApi();

            root.MapGet("/", GetPlanetasAsync)
                .Produces<List<GetPlanetResponse>>()
                .WithSummary("Obtem todos os planetas cadastrados")
                .WithDescription("Endpoint para leitura e retorno da lista de planetas cadastrados");

            root.MapGet("/{id}", GetPlanetasByIdAsync)
                .Produces<GetPlanetResponse>()
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Obtem um planeta cadastrado")
                .WithDescription("Endpoint para leitura e retorno de um planeta cadastrado pelo Id correspondente");
        }

        private static async Task<IResult> GetPlanetasAsync
        (
            int page,
            int take,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            var result = await mediator.Send(new GetPlanetRequest(), cancellationToken);

            var total = result.Count;
            result = result.Skip((page - 1) * take).Take(take).ToList();

            return Results.Ok(new { total, CurrentPage = page, take, result });
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
