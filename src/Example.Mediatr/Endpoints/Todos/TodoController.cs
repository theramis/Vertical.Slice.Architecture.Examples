using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Mediatr.Endpoints.Todos.Contracts;
using Example.Mediatr.Endpoints.Todos.CreateTodo;
using Example.Mediatr.Endpoints.Todos.DeleteTodos;
using Example.Mediatr.Endpoints.Todos.GetTodoById;
using Example.Mediatr.Endpoints.Todos.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.Mediatr.Endpoints.Todos
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetTodoResponse>> GetTodos()
            => AddUrls(await _mediator.Send(new GetTodosQuery()));

        [HttpPost]
        public async Task<GetTodoResponse> CreateTodo(CreateTodoCommand command)
            => AddUrl(await _mediator.Send(command));

        [HttpDelete]
        public async Task DeleteTodo()
            => await _mediator.Send(new DeleteTodosCommand());

        [HttpGet("{id:long}", Name = nameof(GetTodoById))]
        public async Task<GetTodoResponse> GetTodoById(long id)
            => AddUrl(await _mediator.Send(new GetTodoByIdQuery(id)));

        private IEnumerable<GetTodoResponse> AddUrls(IEnumerable<GetTodoResponse> todos)
            => todos.Select(AddUrl);

        private GetTodoResponse AddUrl(GetTodoResponse todo)
        {
            todo.Url = Url.RouteUrl(nameof(GetTodoById), new { id = todo.Id }, Request.Scheme, Request.Host.Value);
            return todo;
        }
    }
}
