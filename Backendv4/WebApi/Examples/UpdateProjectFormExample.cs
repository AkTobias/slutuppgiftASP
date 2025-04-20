using Business.Dtos.Project;
using Swashbuckle.AspNetCore.Filters;

namespace WebApi.examples
{
    public class UpdateProjectFormExample : IExamplesProvider<UpdateProjectForm>
    {
        public UpdateProjectForm GetExamples()
        {
            return new UpdateProjectForm
            {
                Id = "a3b9c712-2f77-437d-92b7-2b6eea123456",
                ProjectName = "Cool Project",
                ClientId = 4,
                OwnerId = 6,
                Description = "Project Description",
                StartDate = new DateTime(2025, 04, 20),
                EndDate = new DateTime(2025, 06, 15),
                Budget = 30000,
                StatusId = 2
            };
        }
    }
}
