using Example.SeparateClasses.Infrastructure;

namespace Example.SeparateClasses.Endpoints.Todos.UpdateTodoById
{
    public class UpdateTodoByIdCommand : IRequest
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
