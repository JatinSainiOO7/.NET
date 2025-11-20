Learn ASP.NET Core MVC — Quick Reference

Purpose
- A compact guide to understanding and working with ASP.NET Core MVC in this project.

What is ASP.NET Core MVC
- MVC = Model-View-Controller: a pattern that separates responsibilities.
  - Model: data and validation (POCO classes, e.g. `Expense`).
  - View: Razor templates that render HTML (`.cshtml`).
  - Controller: handles requests, returns views or data (`HomeController`).

Project structure (typical)
- `Controllers/` — controller classes that derive from `Controller`.
- `Models/` — domain/data classes and validation attributes.
- `Views/` — Razor view files grouped by controller.
- `wwwroot/` — static files (css, js, images).
- `Program.cs` — app startup, service registration, middleware and routing.
- `appsettings.json` — configuration (connection strings, logging).

Key concepts
- Routing: configured in `Program.cs` with `MapControllerRoute` or attribute routing on controllers.
- Dependency Injection: services are registered with `builder.Services.Add...` and injected via constructor parameters.
- Model binding & validation: MVC will bind form/query data to action parameters or model objects and validate attributes like `[Required]`.
- Views: use Razor syntax (`@model`, `@Html`, tag helpers) to generate HTML.

Entity Framework Core (EF Core) basics
1. Register `DbContext` in `Program.cs`:
   - `builder.Services.AddDbContext<VidlyAppContext>(options => options.UseSqlServer(...));`
2. Create models (POCOs).
3. Add a migration: `dotnet ef migrations add InitialCreate` (or `Add-Migration InitialCreate` in PMC).
4. Apply migration: `dotnet ef database update` (or `Update-Database`).

Common CLI commands
- Build: `dotnet build`.
- Run: `dotnet run`.
- Create new MVC project: `dotnet new mvc -n MyApp`.
- Add EF tool (if missing): `dotnet tool install --global dotnet-ef`.
- Add package: `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` and `Microsoft.EntityFrameworkCore.Design`.

Controller example (concept)
- Create a controller named `ExpensesController` with actions: `Index`, `Create`, `Edit`, `Delete`.
- Use dependency injection to get `VidlyAppContext` and use it to query/save entities.

Debugging tips
- If a build reports a locked `apphost.exe` or `*.exe` file, stop the running process (stop debugging or kill the PID) and rebuild.
- Use logs and the browser developer tools to diagnose runtime or UI issues.

Best practices
- Keep controllers thin; move business logic to services.
- Use view models for complex forms to avoid exposing domain models directly to views.
- Validate user input with data annotations and server checks.
- Secure sensitive configuration with user secrets or environment variables in production.

Further reading
- Microsoft Docs: ASP.NET Core MVC fundamentals
- EF Core documentation for migrations and DbContext usage

This project already contains examples: look at `Controllers/HomeController.cs`, `Models/Expense.cs`, `Data/VidlyAppContext.cs`, and `Program.cs` to see wiring of MVC + EF Core.