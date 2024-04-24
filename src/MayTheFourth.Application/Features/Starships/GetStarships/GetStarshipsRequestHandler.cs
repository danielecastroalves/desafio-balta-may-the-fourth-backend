using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Naves.GetStarships
{
  public class GetStarshipRequestHandler : IRequestHandler<GetStarshipsRequest, List<GetStarshipsResponse>>
  {
    private readonly IRepository<FilmEntity> _filmRepository;
    private readonly IRepository<StarshipEntity> _starshipRepository;

    public GetStarshipRequestHandler
    (
      IRepository<FilmEntity> filmRepository,
      IRepository<StarshipEntity> starshipRepository
    )
    {
      _filmRepository = filmRepository;
      _starshipRepository = starshipRepository;
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
      }
    }

  }
}