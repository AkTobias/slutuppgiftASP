using Business.Mappers;
using Business.Models;
using Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Owner
{
    public class OwnerService : IOwnerService
    {
        private readonly OwnerRepository _ownerRepository;

        public OwnerService(OwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }


        public async Task<IEnumerable<OwnerModel>> GetAllAsync()
        {
            var entites = await _ownerRepository.GetAllAsync();
            var models = entites.Select(OwnerMapper.ToModel);
            return models;
        }
    }
}
