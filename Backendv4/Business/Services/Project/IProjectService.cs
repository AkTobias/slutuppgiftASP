using Business.Dtos.Project;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Project
{
    public interface IProjectService
    {
       
        Task<IEnumerable<ProjectModel>> GetAllAsync(string? sortBy = null, string? sortDirection = "asc");

        Task<ProjectModel?> GetByIdAsync(string id);
        Task<ProjectModel?> AddAsync(AddProjectForm form);
        Task<ProjectModel?> UpdateAsync(UpdateProjectForm form);
        Task<bool> DeleteAsync(string id);
    
    }
}
