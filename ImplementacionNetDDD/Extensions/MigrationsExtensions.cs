using Application.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ImplementacionNetDDD.Extensions
{
    public static class MigrationsExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
