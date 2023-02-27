namespace query.me.domain
{
    public interface IQuery<TResponse, TRequest>
    {
        Task<TResponse> Execute(TRequest request);
    }
}