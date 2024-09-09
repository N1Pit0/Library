using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Author.Single;

public record GetAuthorSingleQuery(int Id): IRequest<AuthorQueryDto>;
