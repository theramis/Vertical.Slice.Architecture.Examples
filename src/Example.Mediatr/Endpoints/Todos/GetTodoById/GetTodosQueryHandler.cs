using System.Threading;
using System.Threading.Tasks;
using Example.Mediatr.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Mediatr.Endpoints.Todos.GetTodoById
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, GetTodoByIdResponse>
    {
        private readonly TodoDbContext _dbContext;

        public GetTodoByIdQueryHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetTodoByIdResponse> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == query.Id, cancellationToken);
            return new GetTodoByIdResponse(todo.Id, todo.Title, todo.Completed, todo.Order);
        }
    }
}
