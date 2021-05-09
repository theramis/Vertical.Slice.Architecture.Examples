using Example.Mediatr.Endpoints.Todos.Contracts;
using MediatR;

namespace Example.Mediatr.Endpoints.Todos.GetTodoById
{
    public class GetTodoByIdQuery : IRequest<GetTodoResponse>
    {
        public long Id { get; }

        public GetTodoByIdQuery(long id)
        {
            Id = id;
        }
    }
}
