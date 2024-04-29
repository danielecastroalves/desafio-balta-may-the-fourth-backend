using MediatR;

namespace MayTheFourth.Application.Features.Planets.GetPlanetById
{
    public sealed record GetPlanetByIdRequest(int Id) : IRequest<GetPlanetResponse?>;
}
