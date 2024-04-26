using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Constants;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Vehicles.GetVehicleById
{
    public class GetVehicleByIdRequestHandler : IRequestHandler<GetVehicleByIdRequest, GetVehicleResponse?>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<VehicleEntity> _vehicleRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetVehicleByIdRequestHandler
        (
            IRepository<FilmEntity> filmRepository,
            IRepository<VehicleEntity> vehicleRepository,
            IPopulateResponseListAppService populateResponseListAppService
        )
        {
            _filmRepository = filmRepository;
            _vehicleRepository = vehicleRepository;
            _populateResponseListAppService = populateResponseListAppService;
        }

        public async Task<GetVehicleResponse?> Handle(GetVehicleByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var url = $"{UrlConstants.UrlVehicles}{request.Id}/";

            var vehicle = await _vehicleRepository.GetByFilterAsync(x => x.Url.Equals(url) && x.Active, cancellationToken);

            if (vehicle is null)
                return null;

            var movieList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var result = vehicle.Adapt<GetVehicleResponse>();

            result.Movies = _populateResponseListAppService.GetFilmsList(vehicle.Films, movieList);

            return result;
        }
    }
}
