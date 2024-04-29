using MediatR;

namespace MayTheFourth.Application.Features.Films.GetFilms
{
    public sealed record GetFilmsRequest : IRequest<List<GetFilmsResponse>>;
}
