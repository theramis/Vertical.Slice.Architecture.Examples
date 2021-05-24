namespace Example.SeparateClasses.Endpoints.Todos
{
    public class Todo
    {
        public long Id { get; }

        public string Title { get; set; } = null!;

        public bool Completed { get; set; } = false;

        public long Order { get; set; } = 0;
    }
}
