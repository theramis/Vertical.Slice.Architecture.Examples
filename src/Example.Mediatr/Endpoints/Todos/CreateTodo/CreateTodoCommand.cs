using Example.Mediatr.Endpoints.Todos.GetTodoById;
using MediatR;

namespace Example.Mediatr.Endpoints.Todos.CreateTodo
{
    public class CreateTodoCommand : IRequest<GetTodoByIdResponse>
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
