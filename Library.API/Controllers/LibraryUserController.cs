using Library.Application.DTOs.LibraryUserDto;
using Library.Application.Features.Commands.LibraryUser.Create;
using Library.Application.Features.Commands.LibraryUser.Delete;
using Library.Application.Features.Commands.LibraryUser.Update;
using Library.Application.Features.Queries.GetAllDetails.LibraryUser;
using Library.Application.Features.Queries.GetSingleDetails.LibraryUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibraryUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/libraryUser
        [HttpGet]
        public async Task<ActionResult<List<LibraryUserQueryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetLibraryUserQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        // GET: api/libraryUser/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryUserQueryDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetLibraryUserSingleQuery(id);
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/libraryUser
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateLibraryUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        // PUT: api/libraryUser/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLibraryUserCommand command, CancellationToken cancellationToken)
        {
            if (id != command.LibraryUserUpdateDto.Id)
            {
                return BadRequest("Library User ID mismatch.");
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        // DELETE: api/libraryUser/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteLibraryUserCommand(new LibraryUserDeleteDto { Id = id });
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
