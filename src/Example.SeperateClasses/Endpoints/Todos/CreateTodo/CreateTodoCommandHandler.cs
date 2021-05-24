using System.Threading;
using System.Threading.Tasks;
using Example.SeparateClasses.Endpoints.Todos.GetTodoById;
using Example.SeparateClasses.Infrastructure;

namespace Example.SeparateClasses.Endpoints.Todos.CreateTodo
{
    public class CreateTodoCommandHandler : IHandler<CreateTodoCommand, GetTodoByIdResponse>
    {
        private readonly TodoDbContext _dbContext;

        public CreateTodoCommandHandler(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetTodoByIdResponse> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.AddAsync(new Todo
            {
                Title = command.Title,
                Order = command.Order,
                Completed = false,
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new GetTodoByIdResponse(todo.Entity.Id, todo.Entity.Title, todo.Entity.Completed, todo.Entity.Order);
        }
    }
}
