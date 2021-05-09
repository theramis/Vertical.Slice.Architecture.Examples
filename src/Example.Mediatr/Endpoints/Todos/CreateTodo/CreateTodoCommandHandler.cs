using System.Threading;
using System.Threading.Tasks;
using Example.Mediatr.Endpoints.Todos.Contracts;
using Example.Mediatr.Infrastructure;
using MediatR;

namespace Example.Mediatr.Endpoints.Todos.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, GetTodoResponse>
    {
        private readonly TodoDbContext _dbContext;

        public CreateTodoCommandHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetTodoResponse> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.AddAsync(new Todo
            {
                Title = command.Title
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new GetTodoResponse(todo.Entity.Id, todo.Entity.Title, todo.Entity.Completed);
        }
    }
}
