using MediatR;

namespace Example.Mediatr.Endpoints.Todos.DeleteTodoById
{
    public class DeleteTodoByIdCommand : IRequest
    {
        public long Id { get; }

        public DeleteTodoByIdCommand(long id)
        {
            Id = id;
        }
    }
}
