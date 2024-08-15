using Microsoft.AspNetCore.Mvc;
using TestApplication.Application.DTO;
using TestApplication.Infrastructure.Repositories;

namespace TestApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemRequest request, CancellationToken ct = default)
        {
            var result = await _repository.Save(request, ct);
            if (result.IsFailure) return BadRequest(result.Error);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct = default)
        {
            var items = await _repository.Get(ct);
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct = default)
        {
            var item = await _repository.GetById(id, ct);
            return Ok(item);
        }

        [HttpGet("category/")]
        public async Task<IActionResult> GetByCategory([FromQuery] Guid id, CancellationToken ct = default)
        {
            var items = await _repository.GetByCategory(id, ct);
            return Ok(items);
        }

    }
}
