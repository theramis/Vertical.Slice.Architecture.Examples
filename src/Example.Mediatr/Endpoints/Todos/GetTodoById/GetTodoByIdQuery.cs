using MediatR;

namespace Example.Mediatr.Endpoints.Todos.GetTodoById
{
    public class GetTodoByIdQuery : IRequest<GetTodoByIdResponse>
    {
        public long Id { get; }

        public GetTodoByIdQuery(long id)
        {
            Id = id;
        }
    }
}
