using System.Threading;
using System.Threading.Tasks;

namespace Example.SeparateClasses.Infrastructure
{
    public interface IHandler<in T, TResponse> where T : IRequest
    {
        Task<TResponse> Handle(T request, CancellationToken cancellationToken);
    }

    public interface IHandler<in T> where T : IRequest
    {
        Task Handle(T request, CancellationToken cancellationToken);
    }
}
