using MediatR;

namespace MayTheFourth.Application.Features.Starships.GetStarshipsById
{
    public sealed record GetStarshipByIdRequest(int Id) : IRequest<GetStarshipsResponse?>;
}