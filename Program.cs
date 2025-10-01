using BlazorApp04.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Prefer App Service app setting "KVConnectionStringWebApp04" (can be a Key Vault reference).
// Fall back to the local connection string named "dbDataContext".
var connectionString = builder.Configuration["KVConnectionStringWebApp04"]
    ?? builder.Configuration.GetConnectionString("dbDataContext")
    ?? throw new InvalidOperationException("Connection string not found. Provide 'KVConnectionStringWebApp03' app setting or 'dbDataContext' connection string.");

builder.Services.AddDbContextFactory<dbDataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
