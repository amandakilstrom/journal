using Microsoft.EntityFrameworkCore;
using Journal.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin() //TODO: Change this to a specific origin in production
        .AllowAnyHeader()
        .AllowAnyMethod()));

builder.Services.AddDbContext<JournalDb>(o => 
    o.UseSqlite("Data Source=journal.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<JournalDb>().Database.EnsureCreated();
}

app.UseCors();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();
