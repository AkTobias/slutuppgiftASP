using Data.Entities;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Owner;

namespace Business.Mappers
{
    public class OwnerMapper
    {
        public static OwnerDto ToDto(OwnerModel model) => new()
        {
            Id = model.Id,
            FullName = model.FullName
        };


        public static OwnerModel ToModel(OwnerEntity entity) => new()
        {
            Id = entity.Id,
            FullName = entity.FullName
        };

        public static OwnerEntity ToEntity(OwnerModel model) => new()
        {
            Id = model.Id,
            FullName = model.FullName,
        };
    }
}
