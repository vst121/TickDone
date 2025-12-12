# TickDone

Lightweight TODO API solution built with .NET 10.

## Projects
- `TickDone.API` - ASP.NET Core API (Web) project
- `TickDone.Infrastructure` - EF Core DbContext and data access wiring
- `TickDone.Core` - Domain entities
- `TickDone.Tests` - Unit and integration tests (xUnit)

## Prerequisites
- .NET 10 SDK
- (Optional) `dotnet-ef` tool for migrations: `dotnet tool install --global dotnet-ef`

## Getting started
1. Restore and build
   - `dotnet restore`
   - `dotnet build`

2. Run the API
   - `dotnet run --project TickDone.API`
   - By default the solution is configured to use Sqlite. Connection strings live in `TickDone.API/appsettings.json` and `appsettings.Development.json`.
   - To change provider set `Database:Provider` to `Sqlite` or `SqlServer` and update the matching connection string.

3. Database migrations (if needed)
   - Add/Apply migrations from the solution root (To separate the SQLite from SqlServer migrations pass the output directorty too):
     - `dotnet ef migrations add InitialSqlite --project TickDone.Infrastructure --startup-project TickDone.API --output-dir Migrations/Sqlite`
     - `dotnet ef database update --project TickDone.Infrastructure --startup-project TickDone.API`
   - If using integration tests that rely on `WebApplicationFactory`, consider switching the API to an in-memory provider during tests.

4. Run tests
   - `dotnet test`

## Notes for integration tests
- If tests use `Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<TEntryPoint>`, ensure the API `Program` class is discoverable. You can add a declaration like:

  `public partial class Program { }`

  in `TickDone.API/Program.cs` so `WebApplicationFactory<Program>` can find the entry point.

## Contributing
- Fork, create a feature branch, add tests, and open a pull request.

## License
- This repository does not include a license file. Add one if you plan to publish the code.
