using System.Threading;
using System.Threading.Tasks;
using Example.Mediatr.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Mediatr.Endpoints.Todos.DeleteTodos
{
    public class DeleteTodosCommandHandler : AsyncRequestHandler<DeleteTodosCommand>
    {
        private readonly TodoDbContext _dbContext;

        public DeleteTodosCommandHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(DeleteTodosCommand command, CancellationToken cancellationToken)
        {
            var todos = await _dbContext.Todos.ToListAsync(cancellationToken);

            _dbContext.Todos.RemoveRange(todos);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
