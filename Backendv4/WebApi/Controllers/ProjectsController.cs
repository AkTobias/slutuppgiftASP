using Business.Dtos.Project;
using Business.Services.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Swashbuckle.AspNetCore.Filters;
using WebApi.examples;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string? sortBy = null, string? sortDirection = "asc")
        {
            var projects = await _projectService.GetAllAsync(sortBy, sortDirection);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        [HttpPut("{id}")]
        [SwaggerRequestExample(typeof(UpdateProjectForm), typeof(UpdateProjectFormExample))]
        public async Task<IActionResult> Update(string id, UpdateProjectForm form)
        {
            if(id != form.Id)
            {
                return BadRequest("Wrong Id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            var updated = await _projectService.UpdateAsync(form);
            if(updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _projectService.DeleteAsync(id);
            if(!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        [SwaggerRequestExample(typeof(AddProjectForm), typeof(AddProjectFormExample))]
        public async Task<IActionResult> Add(AddProjectForm form)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newProject = await _projectService.AddAsync(form);
            return CreatedAtAction(nameof(GetById), new { id = newProject!.Id }, newProject);
        }


    }
}
