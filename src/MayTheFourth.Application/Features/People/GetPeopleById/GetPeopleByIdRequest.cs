using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeopleById
{
    public sealed record GetPeopleByIdRequest(int Id) : IRequest<GetPeopleResponse?>;
}
