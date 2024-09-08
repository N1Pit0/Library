using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.LoanDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Loan;

public class GetLoanQueryHandler : IRequestHandler<GetLoanQuery, List<LoanQueryDto>>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public GetLoanQueryHandler(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }
    
    public async Task<List<LoanQueryDto>> Handle(GetLoanQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all authors
        var loans = await _loanRepository.GetAllAsync();

        // Map authors to DTOs
        return _mapper.Map<List<LoanQueryDto>>(loans);
    }
}