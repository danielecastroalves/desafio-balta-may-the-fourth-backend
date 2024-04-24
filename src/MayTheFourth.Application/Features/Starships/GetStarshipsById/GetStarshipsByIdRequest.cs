using MediatR;

namespace MayTheFourth.Application.Features.Naves.GetStarshipsById
{
  public sealed class GetStarshipsByIdRequest(int Id) : IRequest<GetStarshipsByIdResponse?>;
}