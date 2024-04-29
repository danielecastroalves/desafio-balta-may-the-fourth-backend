using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Planets.GetPlanetRequest
{
    public class GetPlanetRequestHandler : IRequestHandler<GetPlanetRequest, List<GetPlanetResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<PersonEntity> _personRepository;
        private readonly IRepository<PlanetEntity> _planetRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetPlanetRequestHandler
        (
            IRepository<FilmEntity> filmRepository,
            IRepository<PersonEntity> personRepository,
            IRepository<PlanetEntity> planetRepository,
            IPopulateResponseListAppService populateResponseListAppService
        )
        {
            _filmRepository = filmRepository;
            _personRepository = personRepository;
            _planetRepository = planetRepository;
            _populateResponseListAppService = populateResponseListAppService;
        }

        public async Task<List<GetPlanetResponse>> Handle(GetPlanetRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var peopleList = await _personRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var planetList = await _planetRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var filmList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var responseList = new List<GetPlanetResponse>();

            foreach (var planet in planetList)
            {
                var response = planet.Adapt<GetPlanetResponse>();

                response.Characters = _populateResponseListAppService.GetPeopleList(planet.Residents, peopleList);
                response.Movies = _populateResponseListAppService.GetFilmsList(planet.Films, filmList);
                responseList.Add(response);
            }

            return responseList;
        }
    }
}
