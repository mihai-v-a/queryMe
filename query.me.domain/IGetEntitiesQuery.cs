using query.me.domain;

public interface IGetEntitiesQuery<T> : IQuery<IEnumerable<T>, Func<T, bool>>
{

}