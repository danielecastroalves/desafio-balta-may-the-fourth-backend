using MayTheFourth.Application.Features.Naves;
using MayTheFourth.Application.Features.Naves.GetStarships;
using MayTheFourth.Application.Features.Naves.GetStarshipById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class StarshipsEndpoints
    {
        public static void MapStarshipsEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/naves")
               .WithTags("Naves")
               .WithOpenApi();

            root.MapGet("/", GetNavesAsync)
                .Produces<List<GetStarshipsResponse>>()
                .WithSummary("Obtêm todas as naves cadastradas")
                .WithDescription("Enpoint para leitura e retorno da lista de naves cadastradas");

            root.MapGet("/{id}", GetNavesByIdAsync)
                .Produces<GetStarshipsResponse>()
                .WithSummary("Obtêm uma nave cadastrada")
                .WithDescription("Endpoit para leitura e retorno de uma nave cadastrada pelo Id correspondente ");
        }

        private static async Task<IResult> GetNavesAsync
       (
           [FromServices] IMediator mediador,
           CancellationToken cancellationToken
       )
        {
            var result = await mediador.Send(new GetStarshipsRequest(), cancellationToken);

            return Results.Ok(result);
        }

        private static async Task<IResult> GetNavesByIdAsync
        (
            [FromRoute] int id,
            [FromServices] IMediator mediator
        )
        {
            var result = await mediator.Send(new GetStarshipByIdRequest(id));

            return Results.Ok(result);
        }

    }
}
