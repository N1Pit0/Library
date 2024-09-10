using Library.Application.DTOs.LoanDto;
using Library.Application.Features.Commands.Loan.Create;
using Library.Application.Features.Commands.Loan.Delete;
using Library.Application.Features.Commands.Loan.Update;
using Library.Application.Features.Queries.GetAllDetails.Loan;
using Library.Application.Features.Queries.GetSingleDetails.Loan;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/loan
        [HttpGet]
        public async Task<ActionResult<List<LoanQueryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetLoanQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        // GET: api/loan/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanQueryDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetLoanSingleQuery(id);
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/loan
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateLoanCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        // PUT: api/loan/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLoanCommand command, CancellationToken cancellationToken)
        {
            if (id != command.LoanUpdateDto.Id)
            {
                return BadRequest("Loan ID mismatch.");
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        // DELETE: api/loan/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteLoanCommand(new LoanDeleteDto { Id = id });
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
