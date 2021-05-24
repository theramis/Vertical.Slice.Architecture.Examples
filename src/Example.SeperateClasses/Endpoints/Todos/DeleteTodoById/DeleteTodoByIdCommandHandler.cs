using System;
using System.Threading;
using System.Threading.Tasks;
using Example.SeparateClasses.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Example.SeparateClasses.Endpoints.Todos.DeleteTodoById
{
    public class DeleteTodoByIdCommandHandler : IHandler<DeleteTodoByIdCommand> 
    {
        private readonly TodoDbContext _dbContext;

        public DeleteTodoByIdCommandHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteTodoByIdCommand command, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == command.Id, cancellationToken);

            if (todo == null)
            {
                throw new Exception($"Could not find Todo with Id {command.Id}");
            }

            _dbContext.Todos.Remove(todo);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
