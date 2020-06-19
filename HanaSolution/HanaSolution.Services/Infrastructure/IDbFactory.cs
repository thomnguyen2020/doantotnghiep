using System;

namespace HanaSolution.Services.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        EntitiesDbContext Init();
    }
}
