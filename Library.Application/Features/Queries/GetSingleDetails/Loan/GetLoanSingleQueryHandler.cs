using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.LoanDto;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.Loan;

public class GetLoanSingleQueryHandler: IRequestHandler<GetLoanSingleQuery, LoanQueryDto>

{
    private readonly IMapper _mapper;
    private readonly ILoanRepository _loanRepository;

    public GetLoanSingleQueryHandler(
        IMapper mapper,
        ILoanRepository loanRepository)
    {
        _mapper = mapper;
        _loanRepository = loanRepository;
    }

    public async Task<LoanQueryDto> Handle(GetLoanSingleQuery request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.Id);

        if (loan == null)
        {
            throw new NotFoundException(nameof(GetAllDetails.Loan), request.Id);
        }

        return _mapper.Map<LoanQueryDto>(loan);
    }
}