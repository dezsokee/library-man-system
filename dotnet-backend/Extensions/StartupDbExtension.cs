namespace webapi.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class StartupDbExtension  {

    public static void CreateDbIfNotExist (this IHost host) {
        using (var scope = host.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BookContext>();
            dbContext.Database.Migrate();
        }
    }
}