﻿using Library.Domain;

namespace Library.Application.Contracts.Persistence;

public interface IBookRepository : IGenericRepository<Book>
{ 
    Task<bool> ExistsAsync(int authorId);
}