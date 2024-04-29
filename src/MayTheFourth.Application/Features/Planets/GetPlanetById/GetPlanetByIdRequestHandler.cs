using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Constants;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Application.Features.Films.GetFilmsById;
using MayTheFourth.Application.Features.Planets;
using MayTheFourth.Application.Features.Planets.GetPlanetById;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Planets.GetPlanetById.GetPlanetById
{
    public class GetPlanetByIdRequestHandler : IRequestHandler<GetPlanetByIdRequest, GetPlanetResponse?>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<PlanetEntity> _planetRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetPlanetByIdRequestHandler
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

        public async Task<GetPlanetResponse?> Handle(GetPlanetByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var url = $"{UrlConstants.UrlPlanets}{request.Id}/";

            var planet = await _planetRepository.GetByFilterAsync(x => x.Url.Equals(url) && x.Active, cancellationToken);

            if (planet is null)
                return null;

            var movieList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var result = planet.Adapt<GetPlanetResponse>();

            result.Movies = _populateResponseListAppService.GetFilmsList(planet.Films, movieList);

            return result;
        }

    }
}
