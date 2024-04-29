using MayTheFourth.Application.Features.Planets;
using MediatR;

namespace MayTheFourth.Application.Planets.GetPlanetById.GetPlanet
{
    public sealed record GetPlanetRequest : IRequest<List<GetPlanetResponse>>;
}
