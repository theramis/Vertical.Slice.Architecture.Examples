﻿using System.Threading;
using System.Threading.Tasks;
using Example.Mediatr.Endpoints.Todos.Contracts;
using Example.Mediatr.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Mediatr.Endpoints.Todos.GetTodoById
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, GetTodoResponse>
    {
        private readonly TodoDbContext _dbContext;

        public GetTodoByIdQueryHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetTodoResponse> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == query.Id, cancellationToken);
            return new GetTodoResponse(todo.Id, todo.Title, todo.Completed);
        }
    }
}
