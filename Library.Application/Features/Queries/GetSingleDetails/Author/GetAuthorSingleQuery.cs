using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.Author;

public record GetAuthorSingleQuery(int Id):
    IRequest<AuthorQueryDto>;
