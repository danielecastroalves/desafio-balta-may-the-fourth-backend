using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Starships.GetStarships
{
    public class GetStarshipRequestHandler : IRequestHandler<GetStarshipsRequest, List<GetStarshipsResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<StarshipEntity> _starshipRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetStarshipRequestHandler
        (
          IRepository<FilmEntity> filmRepository,
          IRepository<StarshipEntity> starshipRepository,
          IPopulateResponseListAppService populateResponseListAppService
        )
        {
            _filmRepository = filmRepository;
            _starshipRepository = starshipRepository;
            _populateResponseListAppService = populateResponseListAppService;
        }

        public async Task<List<GetStarshipsResponse>> Handle(GetStarshipsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filmList = await _filmRepository.GetListByFilterAsync(f => f.Active, cancellationToken);
            var starshipList = await _starshipRepository.GetListByFilterAsync(s => s.Active, cancellationToken);

            var responseList = new List<GetStarshipsResponse>();

            foreach (var starship in starshipList)
            {
                var response = starship.Adapt<GetStarshipsResponse>();

                response.Movies = _populateResponseListAppService.GetFilmsList(starship.Films!, filmList);

                responseList.Add(response);
            }

            return responseList;
        }
    }
}
