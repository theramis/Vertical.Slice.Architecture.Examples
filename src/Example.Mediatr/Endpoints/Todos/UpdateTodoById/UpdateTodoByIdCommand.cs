using Example.Mediatr.Endpoints.Todos.GetTodoById;
using MediatR;

namespace Example.Mediatr.Endpoints.Todos.UpdateTodoById
{
    public class UpdateTodoByIdCommand : IRequest<GetTodoByIdResponse>
    {
        public long Id { get; set; }
        public string? Title { get; }
        public bool? Completed { get; }
        public long? Order { get; }

        public UpdateTodoByIdCommand(string? title = null, bool? completed = null, long? order = null)
        {
            Title = title;
            Completed = completed;
            Order = order;
        }
    }
}
