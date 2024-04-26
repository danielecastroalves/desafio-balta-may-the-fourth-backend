using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeople
{
    public class GetPeopleRequestHandler : IRequestHandler<GetPeopleRequest, List<GetPeopleResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<PersonEntity> _personRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetPeopleRequestHandler
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


        public async Task<List<GetPeopleResponse>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            var people = await _personRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var filmList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var responseList = new List<GetPeopleResponse>();

            foreach (var person in people)
            {
                var adapt = person.Adapt<GetPeopleResponse>();

                adapt.Movies = _populateResponseListAppService.GetFilmsList(person.Films!, filmList);

                responseList.Add(adapt);
            }

            return responseList;
        }
    }
}
