using MediatR;

namespace MayTheFourth.Application.Features.Vehicles.GetVehicle
{
    public sealed record GetVehicleRequest : IRequest<List<GetVehicleResponse>>;
}
