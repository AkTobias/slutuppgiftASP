using Business.Dtos.Project;
using Business.Dtos.Status;
using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class StatusMapper
    {
        public static StatusEntity ToEntity(AddStatusForm formData) => new()
        {
          
            StatusName = formData.StatusName
        };

        public static StatusEntity ToEntity(UpdateStatusForm formData) => new()
        {
            Id = formData.Id,
            StatusName = formData.StatusName
        };

        public static StatusModel? ToModel(StatusEntity entity)
        {
            if (entity == null) return null;

            return new StatusModel
            {
                Id = entity.Id,
                StatusName = entity.StatusName
            };
        }
    }
}
