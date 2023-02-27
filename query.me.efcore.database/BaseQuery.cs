using Microsoft.EntityFrameworkCore;
using query.me.domain;

namespace com.strategikon.maestro.database.QueryObjects
{
    public abstract class BaseQuery<TResponse, TRequest, TContext> : IQuery<TResponse?, TRequest>, IDisposable where TContext : DbContext
    {
        protected IDbContextFactory<TContext> DbContextFactory { get; private set; }

        protected BaseQuery(IDbContextFactory<TContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public async Task<TResponse?> Execute(TRequest request)
        {
            return await Run(request);
        }

        public abstract Task<TResponse?> Run(TRequest request);

        private TContext? _context;
        protected TContext Context
        {
            get
            {
                if (_context == null)
                    _context = DbContextFactory.CreateDbContext();
                return _context;
            }
        }

        public void Dispose()
        {
            if (_context != null)
                try { _context.Dispose(); } catch { }
        }
    }
}