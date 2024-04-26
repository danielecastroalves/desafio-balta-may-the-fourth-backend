using MayTheFourth.Application.Features.Films;
using MayTheFourth.Domain.Entities;


namespace MayTheFourth.Application.Common.AppServices.PopulateStarships
{
  public interface IPopulateStarshipsResponseAppService
  {
    List<ItemDescription>? GetFilmList(StarshipEntity starship, IEnumerable<FilmEntity> filmList);
  }
}