using MediatR;

namespace MayTheFourth.Application.Features.Naves.GetStarshipById
{
  public sealed record GetStarshipByIdRequest(int Id) : IRequest<GetStarshipsResponse?>;
}