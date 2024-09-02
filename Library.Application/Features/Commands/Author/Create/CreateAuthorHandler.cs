using AutoMapper;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Author.Create;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

{
public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public CreateAuthorHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        // var author = _mapper.Map<Domain.Author>(request.CreateAuthorDto);
        //
        // await _authorRepository.AddAsync(author);
        // await _authorRepository.SaveChangesAsync();

        return 0;
    }
}
}
