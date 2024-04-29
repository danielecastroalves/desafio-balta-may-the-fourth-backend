using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Constants;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Naves.GetStarshipById
{
    public class GetStarshipByIdRequestHandler : IRequestHandler<GetStarshipByIdRequest, GetStarshipsResponse?>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<StarshipEntity> _starshipRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetStarshipByIdRequestHandler
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

        public async Task<GetStarshipsResponse?> Handle(GetStarshipByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var url = $"{UrlConstants.UrlStarships}{request.Id}/";

            var starship = await _starshipRepository.GetByFilterAsync(s => s.Url!.Equals(url) && s.Active, cancellationToken);

            if (starship is null)
                return null;

            var movieList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var response = starship.Adapt<GetStarshipsResponse>();

            response.Movies = _populateResponseListAppService.GetFilmsList(starship.Films!, movieList);

            return response;
        }
    }
}
