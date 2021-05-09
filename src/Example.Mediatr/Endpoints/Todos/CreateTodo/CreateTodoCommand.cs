using Example.Mediatr.Endpoints.Todos.Contracts;
using MediatR;

namespace Example.Mediatr.Endpoints.Todos.CreateTodo
{
    public class CreateTodoCommand : IRequest<GetTodoResponse>
    {
        public string Title { get; set; } = string.Empty;
    }
}
