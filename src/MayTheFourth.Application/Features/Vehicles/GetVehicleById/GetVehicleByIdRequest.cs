using MediatR;

namespace MayTheFourth.Application.Features.Vehicles.GetVehicleById
{
    public sealed record GetVehicleByIdRequest(int Id) : IRequest<GetVehicleResponse?>;
}
