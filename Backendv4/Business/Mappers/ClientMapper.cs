using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class ClientMapper
    {
        public static ClientModel ToModel(ClientEntity entity) => new()
        {
            Id = entity.Id,
            ClientName = entity.ClientName,
        };

        public static ClientEntity ToEntity(ClientModel model) => new()
        {
            Id = model.Id,
            ClientName = model.ClientName,
        };
    }
}
