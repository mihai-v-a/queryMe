using com.strategikon.maestro.database.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace query.me.efcore.database
{
    public class GetEntityQuery<T, TContext> : BaseQuery<T, Func<T, bool>, TContext> where T : class where TContext : DbContext
    {
        public GetEntityQuery(IDbContextFactory<TContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public override async Task<T?> Run(Func<T, bool> request) => await Context.Set<T>().SingleOrDefaultAsync(e => request(e));
    }
}