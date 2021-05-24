using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Example.SeparateClasses.Endpoints.Todos.CreateTodo;
using Example.SeparateClasses.Endpoints.Todos.DeleteTodoById;
using Example.SeparateClasses.Endpoints.Todos.DeleteTodos;
using Example.SeparateClasses.Endpoints.Todos.GetTodoById;
using Example.SeparateClasses.Endpoints.Todos.GetTodos;
using Example.SeparateClasses.Endpoints.Todos.UpdateTodoById;
using Example.SeparateClasses.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Example.SeparateClasses.Endpoints.Todos
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GetTodoByIdResponse>> GetTodos(CancellationToken cancellationToken,
            [FromServices] IHandler<GetTodosQuery, IEnumerable<GetTodoByIdResponse>> handler)
            => AddUrls(await handler.Handle(new GetTodosQuery(), cancellationToken));

        [HttpPost]
        public async Task<GetTodoByIdResponse> CreateTodo(CreateTodoCommand command,
            CancellationToken cancellationToken,
            [FromServices] IHandler<CreateTodoCommand, GetTodoByIdResponse> handler)
            => AddUrl(await handler.Handle(command, cancellationToken));

        [HttpDelete]
        public async Task DeleteTodo(CancellationToken cancellationToken,
            [FromServices] IHandler<DeleteTodosCommand> handler)
            => await handler.Handle(new DeleteTodosCommand(), cancellationToken);

        [HttpGet("{id:long}", Name = nameof(GetTodoById))]
        public async Task<GetTodoByIdResponse> GetTodoById(long id,
            CancellationToken cancellationToken,
            [FromServices] IHandler<GetTodoByIdQuery, GetTodoByIdResponse> handler)
            => AddUrl(await handler.Handle(new GetTodoByIdQuery(id), cancellationToken));

        [HttpPatch("{id:long}")]
        public async Task<GetTodoByIdResponse> UpdateTodoById(long id, 
            UpdateTodoByIdCommand command,
            CancellationToken cancellationToken,
            [FromServices] IHandler<UpdateTodoByIdCommand, GetTodoByIdResponse> handler)
        {
            command.Id = id;
            return AddUrl(await handler.Handle(command, cancellationToken));
        }
        
        [HttpDelete("{id:long}")]
        public async Task DeleteTodoById(long id,
            CancellationToken cancellationToken,
            [FromServices] IHandler<DeleteTodoByIdCommand> handler)
            => await handler.Handle(new DeleteTodoByIdCommand(id), cancellationToken);
        
        private IEnumerable<GetTodoByIdResponse> AddUrls(IEnumerable<GetTodoByIdResponse> todos)
            => todos.Select(AddUrl);
        
        private GetTodoByIdResponse AddUrl(GetTodoByIdResponse todoById)
        {
            todoById.Url = Url.RouteUrl(nameof(GetTodoById), new { id = todoById.Id }, Request.Scheme, Request.Host.Value);
            return todoById;
        }
    }
}
