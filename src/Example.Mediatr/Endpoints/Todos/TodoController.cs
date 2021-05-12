using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Mediatr.Endpoints.Todos.CreateTodo;
using Example.Mediatr.Endpoints.Todos.DeleteTodoById;
using Example.Mediatr.Endpoints.Todos.DeleteTodos;
using Example.Mediatr.Endpoints.Todos.GetTodoById;
using Example.Mediatr.Endpoints.Todos.GetTodos;
using Example.Mediatr.Endpoints.Todos.UpdateTodoById;
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
        public async Task<IEnumerable<GetTodoByIdResponse>> GetTodos()
            => AddUrls(await _mediator.Send(new GetTodosQuery()));

        [HttpPost]
        public async Task<GetTodoByIdResponse> CreateTodo(CreateTodoCommand command)
            => AddUrl(await _mediator.Send(command));

        [HttpDelete]
        public async Task DeleteTodo()
            => await _mediator.Send(new DeleteTodosCommand());

        [HttpGet("{id:long}", Name = nameof(GetTodoById))]
        public async Task<GetTodoByIdResponse> GetTodoById(long id)
            => AddUrl(await _mediator.Send(new GetTodoByIdQuery(id)));

        [HttpPatch("{id:long}")]
        public async Task<GetTodoByIdResponse> UpdateTodoById(long id, UpdateTodoByIdCommand command)
        {
            command.Id = id;
            return AddUrl(await _mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task DeleteTodoById(long id)
            => await _mediator.Send(new DeleteTodoByIdCommand(id));

        private IEnumerable<GetTodoByIdResponse> AddUrls(IEnumerable<GetTodoByIdResponse> todos)
            => todos.Select(AddUrl);

        private GetTodoByIdResponse AddUrl(GetTodoByIdResponse todoById)
        {
            todoById.Url = Url.RouteUrl(nameof(GetTodoById), new { id = todoById.Id }, Request.Scheme, Request.Host.Value);
            return todoById;
        }
    }
}
