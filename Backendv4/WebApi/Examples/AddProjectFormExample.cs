using Swashbuckle.AspNetCore.Filters;

namespace WebApi.examples
{
    public class AddProjectFormExample : IExamplesProvider<AddProjectForm>
    {
        public AddProjectForm GetExamples()
        {
            return new AddProjectForm
            {
                ProjectName = "Best Project",
                ClientId = 1,
                OwnerId = 2,
                Description = "Project Description",
                StartDate = new DateTime(2025, 05, 01),
                EndDate = new DateTime(2025, 06, 01),
                Budget = 15000,
                StatusId = 3
            };
        }
    }
}
