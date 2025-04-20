using Business.Dtos.Project;
using Business.Mappers;
using Business.Models;
using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepository _repository;
        private readonly StatusRepository _statusRepository;
        private readonly ApplicationDbContext _context;

        public ProjectService(ProjectRepository repository, StatusRepository statusRepository, ApplicationDbContext context)
        {
            _repository = repository;
            _statusRepository = statusRepository;
            _context = context;
        }

        public async Task<ProjectModel?> AddAsync(AddProjectForm form)
        {
        
            var status = await _statusRepository.GetByIdAsync(form.StatusId);
            var owner = await _context.Owners.FindAsync(form.OwnerId);     
            var client = await _context.Clients.FindAsync(form.ClientId); 

            if (status == null || owner == null || client == null)
                return null;

        
            var entity = ProjectMapper.ToEntity(form);
            entity.Status = status;
            entity.Owner = owner;
            entity.Client = client;

            await _repository.AddAsync(entity);

            return ProjectMapper.ToModel(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _repository.GetAsync(p => p.Id == id);
            if (entity == null) return false;

            await _repository.DeleteAsync(x => x.Id == id);
            return true;
        }
        public async Task<IEnumerable<ProjectModel>> GetAllAsync(string? sortBy = null, string? sortDirection = "asc")
        {
            var entites = await _repository.GetAllAsync();

            var sorted = sortBy?.ToLower() switch
            {
                "name" or "projectName" => sortDirection == "desc"
                ? entites.OrderByDescending(p => p.ProjectName)
                : entites.OrderBy(p => p.ProjectName),

                "startdate" => sortDirection == "desc"
                ? entites.OrderByDescending(p => p.StartDate)
                : entites.OrderBy(p => p.StartDate),

                "enddate" => sortDirection == "desc"
                ? entites.OrderByDescending(p => p.EndDate)
                : entites.OrderBy(p => p.StartDate),

                _ => entites.OrderBy(p => p.ProjectName) 
            };
        

            return sorted.Select(ProjectMapper.ToModel);
        }

     
        public async Task<ProjectModel?> GetByIdAsync(string id)
        {
            var entity = await _repository.GetAsync(p => p.Id == id);
            return entity is null ? null : ProjectMapper.ToModel(entity);
        }

        public async Task<ProjectModel?> UpdateAsync(UpdateProjectForm form)
        {
            var existing = await _repository.GetAsync(p => p.Id == form.Id);
            if (existing == null) return null;

            
            var status = await _statusRepository.GetByIdAsync(form.StatusId);
            var owner = await _context.Owners.FindAsync(form.OwnerId);
            var client = await _context.Clients.FindAsync(form.ClientId);

            if (status == null || owner == null || client == null)
                return null;

         
            existing.ProjectName = form.ProjectName;
            existing.ClientId = form.ClientId;
            existing.OwnerId = form.OwnerId;
            existing.Description = form.Description;
            existing.StartDate = form.StartDate;
            existing.EndDate = form.EndDate;
            existing.Budget = form.Budget;
            existing.StatusId = form.StatusId;

           
            existing.Status = status;
            existing.Owner = owner;
            existing.Client = client;

            try
            {
                await _repository.UpdateAsync(existing);
                return ProjectMapper.ToModel(existing);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency conflict: {ex.Message}");
                return null;
            }
        }



    }
}
