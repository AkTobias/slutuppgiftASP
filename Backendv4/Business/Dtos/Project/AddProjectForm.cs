using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

public class AddProjectForm
{
    [Required(ErrorMessage = "Project name is required")]
    [SwaggerSchema(Description = "Name of the project")]
    public string ProjectName { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "Client ID must be greater than 0.")]
    [SwaggerSchema(Description = "ID of the client")]
    public int ClientId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Owner ID must be greater than 0.")]
    [SwaggerSchema(Description = "ID of the project owner")]
    public int OwnerId { get; set; }

    [SwaggerSchema(Description = "Project description")]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [SwaggerSchema(Description = "Start date of the project")]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [SwaggerSchema(Description = "End date of the project")]
    public DateTime EndDate { get; set; }

    [SwaggerSchema(Description = "Budget for the project")]
    public decimal? Budget { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Status ID must be greater than 0.")]
    [SwaggerSchema(Description = "ID of the project status")]
    public int StatusId { get; set; }
}
