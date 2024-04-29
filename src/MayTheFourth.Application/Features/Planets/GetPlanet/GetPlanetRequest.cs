using MediatR;

namespace MayTheFourth.Application.Features.Planets.GetPlanetRequest
{
    public sealed record GetPlanetRequest : IRequest<List<GetPlanetResponse>>;
}
