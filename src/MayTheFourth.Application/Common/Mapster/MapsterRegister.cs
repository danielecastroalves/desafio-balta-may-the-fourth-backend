using Mapster;
using MayTheFourth.Application.Features.Films;
using MayTheFourth.Application.Features.People;
using MayTheFourth.Application.Features.Planets;
using MayTheFourth.Application.Features.Starships;
using MayTheFourth.Application.Features.Vehicles;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.Mapster
{
    public class MapsterRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<FilmEntity, GetFilmsResponse>()
                .Map(dest => dest.Episode, src => src.Episode_id)
                .Map(dest => dest.OpeningCrawl, src => src.Opening_crawl)
                .Map(dest => dest.ReleaseDate, src => src.Release_date)
                .Ignore(dest => dest.Characters)
                .Ignore(dest => dest.Planets)
                .Ignore(dest => dest.Vehicles)
                .Ignore(dest => dest.Starships);

            config
                .NewConfig<PersonEntity, GetPeopleResponse>()
                .Map(dest => dest.Haircolor, src => src.Hair_color)
                .Map(dest => dest.Skincolor, src => src.Skin_color)
                .Map(dest => dest.Eyecolor, src => src.Eye_color)
                .Map(dest => dest.Birthyear, src => src.Birth_year)
                .Ignore(dest => dest.Movies);

            config
                .NewConfig<PlanetEntity, GetPlanetResponse>()
                .Map(dest => dest.RotationPeriod, src => src.Rotation_Period)
                .Map(dest => dest.OrbitalPeriod, src => src.Orbital_Period)
                .Map(dest => dest.SurfaceWater, src => src.Surface_Water)
                .Ignore(dest => dest.Characters)
                .Ignore(dest => dest.Movies);

            config
                .NewConfig<StarshipEntity, GetStarshipsResponse>()
                .Map(dest => dest.CargoCapacity, src => src.Cargo_Capacity)
                .Map(dest => dest.Class, src => src.Starship_Class)
                .Map(dest => dest.CostInCredits, src => src.Cost_In_Credits)
                .Map(dest => dest.HyperdriveRating, src => src.Hyperdrive_Rating)
                .Map(dest => dest.MaxSpeed, src => src.Max_Atmosphering_Speed)
                .Ignore(dest => dest.Movies);

            config.
                 NewConfig<VehicleEntity, GetVehicleResponse>()
                .Map(dest => dest.CostInCredits, src => src.Cost_In_Credits)
                .Map(dest => dest.MaxAtmospheringSpeed, src => src.Max_Atmosphering_Speed)
                .Map(dest => dest.CargoCapacity, src => src.Cargo_Capacity)
                .Map(dest => dest.VehicleClass, src => src.Vehicle_Class)
                .Ignore(dest => dest.Movies);
        }
    }
}
