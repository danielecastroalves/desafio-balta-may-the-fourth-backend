using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Application.Features.Planets;
using MayTheFourth.Application.Planets.GetPlanetById.GetPlanet;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Vehicles.GetVehicle
{
    public class GetPlanetRequestHandler : IRequestHandler<GetPlanetRequest, List<GetPlanetResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<PlanetEntity> _planetRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetPlanetRequestHandler
        (
            IRepository<FilmEntity> filmRepository,
            IRepository<PlanetEntity> planetRepository,
            IPopulateResponseListAppService populateResponseListAppService
        )
        {
            _filmRepository = filmRepository;
            _planetRepository = planetRepository;
            _populateResponseListAppService = populateResponseListAppService;
        }

        public async Task<List<GetPlanetResponse>> Handle(GetPlanetRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var planetList = await _planetRepository.GetListByFilterAsync(x => x.Active);
            var filmList = await _filmRepository.GetListByFilterAsync(x => x.Active);

            var responseList = new List<GetPlanetResponse>();

            foreach (var planet in planetList)
            {
                var response = planet.Adapt<GetPlanetResponse>();

                response.Movies = _populateResponseListAppService.GetFilmsList(planet.Films, filmList);
                responseList.Add(response);
            }

            return responseList;
        }
    }
}
