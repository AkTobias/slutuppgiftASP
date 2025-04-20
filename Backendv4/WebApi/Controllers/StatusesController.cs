using Business.Dtos.Status;
using Business.Models;
using Business.Services.Status;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusesController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusModel>>> Get()
        {
            return Ok(await _statusService.GetAllStatus());
        }

        [HttpPost]
        public async Task<ActionResult<StatusModel>> Add(AddStatusForm form)
        {
            var created = await _statusService.AddAsync(form);
            return CreatedAtAction(nameof(Get), new { id = created!.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusModel>> Update(int id, UpdateStatusForm form)
        {
            if (id != form.Id)
                return BadRequest("Mismatched ID");

            var updated = await _statusService.UpdateAsync(form);
            return updated is null ? NotFound() : Ok(updated);
        }


    }
}
