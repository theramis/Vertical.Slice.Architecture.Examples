using Example.SeparateClasses.Infrastructure;

namespace Example.SeparateClasses.Endpoints.Todos.CreateTodo
{
    public class CreateTodoCommand : IRequest
    {
        public string Title { get; }
        public long Order { get; }

        public CreateTodoCommand(string title, long order)
        {
            Title = title;
            Order = order;
        }
    }
}
