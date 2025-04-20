using Business.Mappers;
using Business.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        

        public async Task<IEnumerable<ClientModel>> GetAllClients()
        {
            var entites = await _clientRepository.GetAllAsync();
            var models = entites.Select(ClientMapper.ToModel);
            return models;

        }
    }
}
