using Microsoft.EntityFrameworkCore;
using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Repositories;
using Module4_HM4_EF2.Repositories.Abstractions;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<bool> CreateAsync(string name)
        {
            var existingLocation = await _locationRepository.GetByNameAsync(name);
            if (existingLocation != null) return false;

            var newLocation = new Location { LocationName = name };
            await _locationRepository.CreateAsync(newLocation);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _locationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LocationDTO>> GetAllAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            return locations.Select(location => new LocationDTO { Id = location.Id, LocationName = location.LocationName });
        }

        public async Task<LocationDTO> GetByIdAsync(int id)
        {
            var existingLocation = await _locationRepository.GetByIdAsync(id);
            if (existingLocation != null) return new LocationDTO { Id = existingLocation.Id, LocationName = existingLocation.LocationName };
            return null;
        }

        public async Task<LocationDTO> GetByNameAsync(string name)
        {
            var existingLocation = await _locationRepository.GetByNameAsync(name);

            if (existingLocation == null) return null;

            return new LocationDTO { Id = existingLocation.Id, LocationName = existingLocation.LocationName};
        }

        public async Task<bool> UpdateAsync(LocationDTO item)
        {
            var checkName = await _locationRepository.GetByNameAsync(item.LocationName);
            if (checkName != null) return false;

            var location = new Location { Id = item.Id, LocationName = item.LocationName };
            return await _locationRepository.UpdateAsync(location);
        }
    }
}
