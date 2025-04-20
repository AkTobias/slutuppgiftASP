using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Dtos.Project;
using Business.Models;
using Data.Entities;
using Microsoft.SqlServer.Server;

namespace Business.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectEntity ToEntity(AddProjectForm formdata) => new()
        {
           
            ProjectName = formdata.ProjectName,
            ClientId = formdata.ClientId,
            OwnerId = formdata.OwnerId,
            Description = formdata.Description,
            StartDate = formdata.StartDate,
            EndDate = formdata.EndDate,
            Budget = formdata.Budget,
            Created = DateTime.Now,
            StatusId = formdata.StatusId,
            
        };

        public static ProjectEntity ToEntity(UpdateProjectForm formdata) => new()
        {
         
            Id = formdata.Id,
            ProjectName = formdata.ProjectName,
            ClientId = formdata.ClientId,
            OwnerId = formdata.OwnerId,
            Description = formdata.Description,
            StartDate = formdata.StartDate,
            EndDate = formdata.EndDate,
            Budget = formdata.Budget,
            StatusId = formdata.StatusId,

        };

        public static ProjectModel ToModel(ProjectEntity entity)
        {
            if (entity.Status == null)
                throw new InvalidOperationException("Status is required for this project.");

            return new ProjectModel
            {
                Id = entity.Id,
                ProjectName = entity.ProjectName,
                ClientId = entity.ClientId,
                OwnerId = entity.OwnerId,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Budget = entity.Budget,
                Created = entity.Created,
                Client = ClientMapper.ToModel(entity.Client),
                Owner = OwnerMapper.ToModel(entity.Owner),
                Status = StatusMapper.ToModel(entity.Status)
            };
        }



    }
}