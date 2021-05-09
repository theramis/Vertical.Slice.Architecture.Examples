namespace Example.Mediatr.Endpoints.Todos
{
    public class Todo
    {
        public long Id { get; }

        public string Title { get; set; } = null!;

        public bool Completed { get; } = false;
    }
}
