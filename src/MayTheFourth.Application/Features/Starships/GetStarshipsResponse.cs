﻿namespace MayTheFourth.Application.Features.Naves
{
    public class GetStarshipsResponse
    {
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public float CostInCredits { get; set; }
        public float Length { get; set; }
        public double MaxSpeed { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public double cargoCapacity { get; set; }
        public float HyperdriveRating { get; set; }
        public int Mglt { get; set; }
        public TimeSpan Consumables { get; set; }
        public string Class { get; set; } = null!;
        public List<ItemDescription>? Movies { get; set; }
    }

    public class ItemDescription
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
    }
}
