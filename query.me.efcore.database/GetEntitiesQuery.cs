using com.strategikon.maestro.database.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace query.me.efcore.database
{
    public class GetEntitiesQuery<T, TContext> :
        BaseQuery<IEnumerable<T>, Func<T, bool>, TContext>,
        IGetEntitiesQuery<T> where T : class where TContext : DbContext
    {
        public GetEntitiesQuery(IDbContextFactory<TContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public override async Task<IEnumerable<T>> Run(Func<T, bool> request) => await Context.Set<T>().Where(e => request(e)).ToListAsync();
    }
}