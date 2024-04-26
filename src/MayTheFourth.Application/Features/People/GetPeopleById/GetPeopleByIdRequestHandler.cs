using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Constants;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeopleById
{
    public class GetPeopleByIdRequestHandler : IRequestHandler<GetPeopleByIdRequest, GetPeopleResponse?>
    {
        private readonly IRepository<PersonEntity> _personRepository;
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetPeopleByIdRequestHandler
        (
            IRepository<PersonEntity> personRepository,
            IRepository<FilmEntity> filmRepository,
            IPopulateResponseListAppService populateResponseListAppService
        )
        {
            _personRepository = personRepository;
            _filmRepository = filmRepository;
            _populateResponseListAppService = populateResponseListAppService;
        }

        public async Task<GetPeopleResponse?> Handle(GetPeopleByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var url = $"{UrlConstants.UrlPeople}{request.Id}/";

            var people = await _personRepository.GetByFilterAsync(x => x.Url!.Equals(url) && x.Active, cancellationToken);

            if (people is null)
                return null;

            var movieList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var result = people.Adapt<GetPeopleResponse>();

            result.Movies = _populateResponseListAppService.GetFilmsList(people.Films!, movieList);

            return result;
        }
    }
}
