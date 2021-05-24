using System.Collections.Generic;
using System.Reflection;
using Example.SeparateClasses.Endpoints.Todos.CreateTodo;
using Example.SeparateClasses.Endpoints.Todos.DeleteTodoById;
using Example.SeparateClasses.Endpoints.Todos.DeleteTodos;
using Example.SeparateClasses.Endpoints.Todos.GetTodoById;
using Example.SeparateClasses.Endpoints.Todos.GetTodos;
using Example.SeparateClasses.Endpoints.Todos.UpdateTodoById;
using Example.SeparateClasses.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Example.SeparateClasses
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", opts =>
                {
                    opts.AllowAnyOrigin();
                    opts.AllowAnyHeader();
                    opts.AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetExecutingAssembly().GetName().Name, Version = "v1" });
            });

            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMem");
            });

            RegisterHandlers(services);
        }

        private static void RegisterHandlers(IServiceCollection services)
        {
            services.AddScoped<IHandler<CreateTodoCommand, GetTodoByIdResponse>, CreateTodoCommandHandler>();
            services.AddScoped<IHandler<GetTodoByIdQuery, GetTodoByIdResponse>, GetTodoByIdQueryHandler>();
            services.AddScoped<IHandler<DeleteTodoByIdCommand>, DeleteTodoByIdCommandHandler>();
            services.AddScoped<IHandler<DeleteTodosCommand>, DeleteTodosCommandHandler>();
            services.AddScoped<IHandler<GetTodosQuery, IEnumerable<GetTodoByIdResponse>>, GetTodosQueryHandler>();
            services.AddScoped<IHandler<UpdateTodoByIdCommand, GetTodoByIdResponse>, UpdateTodoByIdCommandHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Assembly.GetExecutingAssembly().GetName().Name} v1"));
            }

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
