using Library.Application.DTOs.BookDto;
using Library.Application.Features.Commands.Book.Create;
using Library.Application.Features.Commands.Book.Delete;
using Library.Application.Features.Commands.Book.Update;
using Library.Application.Features.Queries.GetAllDetails.Book;
using Library.Application.Features.Queries.GetSingleDetails.Book;

namespace Library.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/book
    [HttpGet]
    public async Task<ActionResult<List<BookQueryDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetBookQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    // GET: api/book/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<BookQueryDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetBookSingleQuery(id);
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    // POST: api/book
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateBookCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    // PUT: api/book/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCommand command, CancellationToken cancellationToken)
    {
        if (id != command.BookUpdateDto.Id)
        {
            return BadRequest("Book ID mismatch.");
        }

        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    // DELETE: api/book/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteBookCommand(new BookDeleteDto{Id = id});
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }
}
