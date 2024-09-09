using Library.Application.DTOs.AuthorDto;
using Library.Application.Features.Commands.Author.Delete;
using Library.Application.Features.Commands.Author.Update;
using Library.Application.Features.Queries.GetAllDetails.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/author
        [HttpGet]
        public async Task<ActionResult<List<AuthorQueryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAuthorQuery(new AuthorQueryDto());
            var result = await _mediator.Send(query, cancellationToken);
            
            return Ok(result);
        }
        
       
        // PUT: api/author/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            if (id != command.AuthorUpdateDto.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        // DELETE: api/author/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteAuthorCommand(new AuthorDeleteDto { Id = id });
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
