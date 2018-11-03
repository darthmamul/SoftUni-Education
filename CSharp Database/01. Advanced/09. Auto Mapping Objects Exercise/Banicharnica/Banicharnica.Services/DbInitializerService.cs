namespace Banicharnica.Services
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Services.Contracts;
    
    public class DbInitializerService : IDbInitializerService
    {
        private readonly BanicharnicaContext context;

        public DbInitializerService(BanicharnicaContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
