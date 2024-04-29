using MayTheFourth.Application.Features.Vehicles;
using MayTheFourth.Application.Features.Vehicles.GetVehicle;
using MayTheFourth.Application.Features.Vehicles.GetVehicleById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class VehiclesEndpoints
    {
        public static void MapVehiclesEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/Vehicles").WithTags("Vehicles").WithOpenApi();

            root.MapGet("/", GetVehiclesAsync)
                .Produces<List<GetVehicleResponse>>()
                .WithSummary("Obtem todos os veiculos cadastrados")
                .WithDescription("Endpoint para leitura e retorno da lista de veiculos cadastrados");

            root.MapGet("/{id:int}", GetVehiclesByIdAsync)
                .Produces<GetVehicleResponse>()
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Obtem um veiculo cadastrado")
                .WithDescription("Endpoint para leitura e retorno de um veiculo cadastrado pelo Id correspondente");
        }

        private static async Task<IResult> GetVehiclesAsync
        (
            int page,
            int take,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            var result = await mediator.Send(new GetVehicleRequest(), cancellationToken);

            var total = result.Count;
            result = result.Skip((page - 1) * take).Take(take).ToList();

            return Results.Ok(new { total, CurrentPage = page, take, result });
        }

        private static async Task<IResult> GetVehiclesByIdAsync
        (
            [FromRoute] int id,
            [FromServices] IMediator mediator
        )
        {
            var result = await mediator.Send(new GetVehicleByIdRequest(id));

            if (result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }
    }
}
