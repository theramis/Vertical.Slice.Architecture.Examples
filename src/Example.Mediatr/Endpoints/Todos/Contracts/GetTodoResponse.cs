using System;

namespace Example.Mediatr.Endpoints.Todos.Contracts
{
    public class GetTodoResponse
    {
        public GetTodoResponse(long id, string title, bool completed)
        {
            Id = id;
            Title = title;
            Completed = completed;
        }

        public long Id { get; }
        public string Title { get; }
        public bool Completed { get; }

        public string Url { get; set; } = string.Empty;
    }
}
