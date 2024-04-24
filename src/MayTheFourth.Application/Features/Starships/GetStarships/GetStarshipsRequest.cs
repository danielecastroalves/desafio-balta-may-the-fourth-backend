using MediatR;

namespace MayTheFourth.Application.Features.Naves.GetStarships
{
  public sealed class GetStarshipsRequest : IRequest<List<GetStarshipsResponse>>;
}