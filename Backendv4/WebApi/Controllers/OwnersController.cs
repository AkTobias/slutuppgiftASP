using Business.Dtos.Owner;
using Business.Mappers;
using Business.Services.Owner;
using Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetOwners()
        {
            var ownerModels = await _ownerService.GetAllAsync();        
            var ownerDtos = ownerModels.Select(OwnerMapper.ToDto);       
            return Ok(ownerDtos);                                       
        }


    }
}
