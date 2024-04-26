using MayTheFourth.Application.Features.Films;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulateStarships
{
  public class PopulateStarshipsResponseAppService : IPopulateStarshipsResponseAppService
  {
    public List<ItemDescription>? GetFilmList(StarshipEntity starship, IEnumerable<FilmEntity> filmList)
    {
      var movies = new List<ItemDescription>();

      foreach (var item in starship.Films!)
      {
        var entity = filmList.FirstOrDefault(f => f.Url.Equals(item));

        if (entity is null) continue;

        var id = entity.Url.TrimEnd('/').Split('/');
        string idString = id[^1];

        movies.Add(new ItemDescription()
        {
          Id = Convert.ToInt32(idString),
          Name = entity.Title,
        });
      }
      return movies();
    }
  }
}