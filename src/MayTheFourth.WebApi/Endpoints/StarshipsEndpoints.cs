using MayTheFourth.Application.Features.Starships;
using MayTheFourth.Application.Features.Starships.GetStarships;
using MayTheFourth.Application.Features.Starships.GetStarshipsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class StarshipsEndpoints
    {
        public static void MapStarshipsEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/starships")
               .WithTags("Starships")
               .WithOpenApi();

            root.MapGet("/", GetNavesAsync)
                .Produces<List<GetStarshipsResponse>>()
                .WithSummary("Obtem todas as naves cadastradas")
                .WithDescription("Enpoint para leitura e retorno da lista de naves cadastradas");

            root.MapGet("/{id}", GetNavesByIdAsync)
                .Produces<GetStarshipsResponse>()
                .WithSummary("Obtem uma nave cadastrada")
                .WithDescription("Endpoit para leitura e retorno de uma nave cadastrada pelo Id correspondente ");
        }

        private static async Task<IResult> GetNavesAsync
        (
           int page,
           int take,
           [FromServices] IMediator mediador,
           CancellationToken cancellationToken
        )
        {
            var result = await mediador.Send(new GetStarshipsRequest(), cancellationToken);

            var total = result.Count;
            result = result.Skip((page - 1) * take).Take(take).ToList();

            return Results.Ok(new { total, CurrentPage = page, take, result });
        }

        private static async Task<IResult> GetNavesByIdAsync
        (
            [FromRoute] int id,
            [FromServices] IMediator mediator
        )
        {
            var result = await mediator.Send(new GetStarshipByIdRequest(id));

            if (result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }
    }
}
