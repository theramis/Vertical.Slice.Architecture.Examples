using System;
using System.Threading;
using System.Threading.Tasks;
using Example.SeparateClasses.Endpoints.Todos.GetTodoById;
using Example.SeparateClasses.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Example.SeparateClasses.Endpoints.Todos.UpdateTodoById
{
    public class UpdateTodoByIdCommandHandler : IHandler<UpdateTodoByIdCommand, GetTodoByIdResponse>
    {
        private readonly TodoDbContext _dbContext;

        public UpdateTodoByIdCommandHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetTodoByIdResponse> Handle(UpdateTodoByIdCommand command, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == command.Id, cancellationToken: cancellationToken);

            if (todo == null)
            {
                throw new Exception($"Could not find Todo with Id {command.Id}");
            }

            if (command.Title != null) todo.Title = command.Title;
            if (command.Completed.HasValue) todo.Completed = command.Completed.Value;
            if (command.Order.HasValue) todo.Order = command.Order.Value;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return new GetTodoByIdResponse(todo.Id, todo.Title, todo.Completed, todo.Order);
        }
    }
}
