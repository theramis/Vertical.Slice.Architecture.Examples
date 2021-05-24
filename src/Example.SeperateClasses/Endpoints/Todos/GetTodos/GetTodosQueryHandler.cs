using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Example.SeparateClasses.Endpoints.Todos.GetTodoById;
using Example.SeparateClasses.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Example.SeparateClasses.Endpoints.Todos.GetTodos
{
    public class GetTodosQueryHandler : IHandler<GetTodosQuery, IEnumerable<GetTodoByIdResponse>>
    {
        private readonly TodoDbContext _dbContext;

        public GetTodosQueryHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetTodoByIdResponse>> Handle(GetTodosQuery query, CancellationToken cancellationToken)
        {
            var todos = await _dbContext.Todos.ToListAsync(cancellationToken);
            return todos.Select(t => new GetTodoByIdResponse(t.Id, t.Title, t.Completed, t.Order));
        }
    }
}
