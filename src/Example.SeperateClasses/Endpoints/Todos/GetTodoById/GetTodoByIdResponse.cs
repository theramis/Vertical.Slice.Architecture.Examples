namespace Example.SeparateClasses.Endpoints.Todos.GetTodoById
{
    public class GetTodoByIdResponse
    {
        public GetTodoByIdResponse(long id, string title, bool completed, long order)
        {
            Id = id;
            Title = title;
            Completed = completed;
            Order = order;
        }

        public long Id { get; }
        public string Title { get; }
        public bool Completed { get; }
        public long Order { get; }

        public string Url { get; set; } = string.Empty;
    }
}
