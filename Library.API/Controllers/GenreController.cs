using Library.Application.DTOs.GenreDto;
using Library.Application.Features.Commands.Genre.Create;
using Library.Application.Features.Commands.Genre.Delete;
using Library.Application.Features.Commands.Genre.Update;
using Library.Application.Features.Queries.GetAllDetails.Genre;
using Library.Application.Features.Queries.GetSingleDetails.Genre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/genre
        [HttpGet]
        public async Task<ActionResult<List<GenreQueryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetGenreQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        // GET: api/genre/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreQueryDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetGenreSingleQuery(id);
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/genre
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateGenreCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        // PUT: api/genre/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGenreCommand command, CancellationToken cancellationToken)
        {
            if (id != command.GenreUpdateDto.Id)
            {
                return BadRequest("Genre ID mismatch.");
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        // DELETE: api/genre/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteGenreCommand(new GenreDeleteDto { Id = id });
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
