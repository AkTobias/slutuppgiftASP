using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos.Project
{
    public class UpdateProjectForm
    {
        [Required(ErrorMessage = "Project ID is required.")]
        [SwaggerSchema(Description = "Unique identifier for the project")]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Project name is required.")]
        [SwaggerSchema(Description = "Name of the project")]
        public string ProjectName { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Client ID is required.")]
        [SwaggerSchema(Description = "ID of the client")]
        public int ClientId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Owner ID is required.")]
        [SwaggerSchema(Description = "ID of the project owner")]
        public int OwnerId { get; set; }

        [SwaggerSchema(Description = "Optional project description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "Start date of the project")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "End date of the project")]
        public DateTime EndDate { get; set; }

        [SwaggerSchema(Description = "Budget for the project")]
        public decimal? Budget { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Status ID is required.")]
        [SwaggerSchema(Description = "ID of the project status")]
        public int StatusId { get; set; }
    }
}
