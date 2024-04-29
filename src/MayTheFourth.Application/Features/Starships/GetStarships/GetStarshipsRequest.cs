using MediatR;

namespace MayTheFourth.Application.Features.Starships.GetStarships
{
    public sealed class GetStarshipsRequest : IRequest<List<GetStarshipsResponse>>;
}
