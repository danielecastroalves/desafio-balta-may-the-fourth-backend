using MayTheFourth.Application.Common.ClassBase;

namespace MayTheFourth.Application.Features.Starships
{
    public class GetStarshipsResponse
    {
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string CostInCredits { get; set; } = null!;
        public string Length { get; set; } = null!;
        public string MaxSpeed { get; set; } = null!;
        public string Crew { get; set; } = null!;
        public string Passengers { get; set; } = null!;
        public string CargoCapacity { get; set; } = null!;
        public string HyperdriveRating { get; set; } = null!;
        public string MGTL { get; set; } = null!;
        public string Consumables { get; set; } = null!;
        public string Class { get; set; } = null!;
        public List<ItemDescription>? Movies { get; set; }
    }
}
