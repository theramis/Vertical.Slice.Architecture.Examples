using System.Collections.Generic;
using Example.Mediatr.Endpoints.Todos.Contracts;
using MediatR;

namespace Example.Mediatr.Endpoints.Todos.GetTodos
{
    public class GetTodosQuery : IRequest<IEnumerable<GetTodoResponse>>
    {
    }
}
