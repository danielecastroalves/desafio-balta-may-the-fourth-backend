using MayTheFourth.Application.Common.ClassBase;

namespace MayTheFourth.Application.Features.Planets
{
    public class GetPlanetResponse
    {
        public string Name { get; set; } = null!;
        public string RotationPeriod { get; set; } = null!;
        public string OrbitalPeriod { get; set; } = null!;
        public string Diameter { get; set; } = null!;
        public string Climate { get; set; } = null!;
        public string Gravity { get; set; } = null!;
        public string Terrain { get; set; } = null!;
        public string SurfaceWater { get; set; } = null!;
        public string Population { get; set; } = null!;
        public List<ItemDescription>? Characters { get; set; }
        public List<ItemDescription>? Movies { get; set; }
    }
}
