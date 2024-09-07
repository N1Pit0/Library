using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Author;

public record GetAuthorQuery(
    AuthorQueryDto AuthorQueryDto) : IRequest<List<AuthorQueryDto>>;
