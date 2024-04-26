using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateResponseList;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Vehicles.GetVehicle
{
    public class GetVehicleRequestHandler : IRequestHandler<GetVehicleRequest, List<GetVehicleResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<VehicleEntity> _vehicleRepository;
        private readonly IPopulateResponseListAppService _populateResponseListAppService;

        public GetVehicleRequestHandler
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

        public async Task<List<GetVehicleResponse>> Handle(GetVehicleRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var vehicleList = await _vehicleRepository.GetListByFilterAsync(x => x.Active);
            var filmList = await _filmRepository.GetListByFilterAsync(x => x.Active);

            var responseList = new List<GetVehicleResponse>();

            foreach (var vehicle in vehicleList)
            {
                var response = vehicle.Adapt<GetVehicleResponse>();

                response.Movies = _populateResponseListAppService.GetFilmsList(vehicle.Films, filmList);

                responseList.Add(response);
            }

            return responseList;
        }
    }
}
