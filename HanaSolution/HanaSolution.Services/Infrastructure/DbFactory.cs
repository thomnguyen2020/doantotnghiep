namespace HanaSolution.Services.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        EntitiesDbContext dbContext;
        public EntitiesDbContext Init()
        {
            return dbContext ?? (dbContext = new EntitiesDbContext());
        }

        protected override void DiposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
