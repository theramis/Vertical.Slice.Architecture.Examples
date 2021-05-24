using Example.SeparateClasses.Infrastructure;

namespace Example.SeparateClasses.Endpoints.Todos.GetTodoById
{
    public class GetTodoByIdQuery : IRequest
    {
        public long Id { get; }

        public GetTodoByIdQuery(long id)
        {
            Id = id;
        }
    }
}
