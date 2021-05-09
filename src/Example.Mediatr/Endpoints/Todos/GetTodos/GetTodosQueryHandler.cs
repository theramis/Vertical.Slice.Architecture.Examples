using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Example.Mediatr.Endpoints.Todos.Contracts;
using Example.Mediatr.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Mediatr.Endpoints.Todos.GetTodos
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<GetTodoResponse>>
    {
        private readonly TodoDbContext _dbContext;

        public GetTodosQueryHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetTodoResponse>> Handle(GetTodosQuery query, CancellationToken cancellationToken)
        {
            var todos = await _dbContext.Todos.ToListAsync(cancellationToken);
            return todos.Select(t => new GetTodoResponse(t.Id, t.Title, t.Completed));
        }
    }
}
