using System.Collections.Generic;
using Example.Mediatr.Endpoints.Todos.GetTodoById;
using MediatR;

namespace Example.Mediatr.Endpoints.Todos.GetTodos
{
    public class GetTodosQuery : IRequest<IEnumerable<GetTodoByIdResponse>>
    {
    }
}
