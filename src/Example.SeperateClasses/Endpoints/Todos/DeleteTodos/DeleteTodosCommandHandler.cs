using System.Threading;
using System.Threading.Tasks;
using Example.SeparateClasses.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Example.SeparateClasses.Endpoints.Todos.DeleteTodos
{
    public class DeleteTodosCommandHandler : IHandler<DeleteTodosCommand>
    {
        private readonly TodoDbContext _dbContext;

        public DeleteTodosCommandHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteTodosCommand command, CancellationToken cancellationToken)
        {
            var todos = await _dbContext.Todos.ToListAsync(cancellationToken);

            _dbContext.Todos.RemoveRange(todos);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
