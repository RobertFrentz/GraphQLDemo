using GettingStarted.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<AppDbContext>(options => 
    options.UseSqlite("Data source=app.db"));

builder.AddGraphQL()
    .RegisterDbContextFactory<AppDbContext>()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
