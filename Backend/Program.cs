using Backend.Endpoints;
using Backend.Persistence;
using HealthChecks.UI.Client;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication()
    .AddCookie(_ =>
    {
        _.LoginPath = "/Login";
        _.LogoutPath = "/Logout";
        _.AccessDeniedPath = "/AccessDenied";
        _.ReturnUrlParameter = "RedirectTo";
    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Database");

// maybe we don't need this, but it is cool!.
//builder.Services.AddHealthChecksUI(_ =>
//{
//    _.AddHealthCheckEndpoint("backend", "/health");
//})
//    .AddInMemoryStorage();

builder.Services.AddHealthChecks()
    .AddNpgSql(connectionString!);

builder.Services.AddDbContext<BellaDbContext>(_ =>
{
    _
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
        .UseNpgsql(connectionString);
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/health", new()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
})
    .WithOpenApi()
    .AllowAnonymous();

app.UseStaticFiles();

app.UseRouting();
// maybe we don't need this, but it is cool!.
//  .UseEndpoints(config => config.MapHealthChecksUI());

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

var api = app.MapGroup("/api")
    .WithOpenApi()
    .RequireAuthorization();
api.MapIngredientsEndpoints();

await using (var scope = app.Services.CreateAsyncScope())
{
    var provider = scope.ServiceProvider;
    var context = provider.GetRequiredService<BellaDbContext>();

    await context.Database.MigrateAsync();
}

app.Run();
