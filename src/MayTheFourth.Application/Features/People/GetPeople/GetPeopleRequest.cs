using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeople
{
    public sealed record GetPeopleRequest : IRequest<List<GetPeopleResponse>>;
}
