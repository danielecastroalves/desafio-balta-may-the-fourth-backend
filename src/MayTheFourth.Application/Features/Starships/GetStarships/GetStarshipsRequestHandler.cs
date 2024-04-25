using MayTheFourth.Application.Common.AppServices.PopulateFilms;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Naves.GetStarships
{
  public class GetStarshipRequestHandler : IRequestHandler<GetStarshipsRequest, List<GetStarshipsResponse>>
  {
    private readonly IRepository<FilmEntity> _filmRepository;
    private readonly IRepository<StarshipEntity> _starshipRepository;
    private readonly IPopulateStarshipsResponseAppService _populateStarshipsAppService;

    public GetStarshipRequestHandler
    (
      IRepository<FilmEntity> filmRepository,
      IRepository<StarshipEntity> starshipRepository,
      IPopulateStarshipsResponseAppService populateStarshipsResponseAppService
    )
    {
      _filmRepository = filmRepository;
      _starshipRepository = starshipRepository;
      _populateStarshipsAppService = populateStarshipsAppService;
    }

    public async Task<List<GetStarshipsResponse>> Handle(GetStarshipsRequest request, CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();

      var filmList = await _filmRepository.GetListByFilterAsync(f => f.Active, cancellationToken);
      var starshipsList = await _starshipRepository.GetByFilterAsync(s => s.Active, cancellationToken);

      var responseList = new List<GetStarshipsResponse>();

      foreach (var starship in starshipsList)
      {
        var response = starship.Adapt<GetStarshipsResponse>();

        response.Movies = _populateStarshipAppService.GetFilmsList(starship, filmList);

        responseList.Add(response);
      }

      return responseList;
    }
  }
}