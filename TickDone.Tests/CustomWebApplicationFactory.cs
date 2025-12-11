namespace TickDone.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the real DbContext registration
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

            //if (descriptor != null)
            //    services.Remove(descriptor);

            //// Add in-memory database for tests
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseInMemoryDatabase("TestDb"));
        });

        builder.UseEnvironment("Testing");
    }
}