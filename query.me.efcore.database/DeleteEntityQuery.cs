using com.strategikon.maestro.database.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace query.me.efcore.database
{
    public class DeleteEntityQuery<T, TContext> : BaseQuery<T, Func<T, bool>, TContext> where T : class where TContext : DbContext
    {
        public DeleteEntityQuery(IDbContextFactory<TContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public override async Task<T?> Run(Func<T, bool> request)
        {
            T? entity = await Context.Set<T>().SingleOrDefaultAsync(e => request(e));
            if (entity == null)
            {
                return null;
            }

            Context.Remove(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
