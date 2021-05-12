using System;
using System.Threading;
using System.Threading.Tasks;
using Example.Mediatr.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Mediatr.Endpoints.Todos.DeleteTodoById
{
    public class DeleteTodoByIdCommandHandler : AsyncRequestHandler<DeleteTodoByIdCommand>
    {
        private readonly TodoDbContext _dbContext;

        public DeleteTodoByIdCommandHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(DeleteTodoByIdCommand command, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == command.Id, cancellationToken: cancellationToken);

            if (todo == null)
            {
                throw new Exception($"Could not find Todo with Id {command.Id}");
            }

            _dbContext.Todos.Remove(todo);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
