using final_project.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*
    When I added a new table, I had to run these commands in command prompt before it would work.

    dotnet ef migrations add InitialCreate --context ContactContext
    dotnet ef database update --context ContactContext


    dotnet ef migrations add InitialCreate --context VideoGameContext
    dotnet ef database update --context VideoGameContext
 */

// Add services to the container.
builder.Services.AddControllers();

// TeamMember Table and DAO
builder.Services.AddDbContext<TeamMemberContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeamMembersContext")));
builder.Services.AddScoped<TeamMemberContextDAO>();

// Contact Table and DAO
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsContext")));
builder.Services.AddScoped<ContactContextDAO>();

// VideoGame Table and DAO
builder.Services.AddDbContext<VideoGameContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideoGamesContext")));
builder.Services.AddScoped<VideoGameContextDAO>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();

builder.Services.AddScoped<PizzaRestaurantDAO>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var contexts = new DbContext[]
    {
        // add Context files here
        scope.ServiceProvider.GetRequiredService<TeamMemberContext>(),
        scope.ServiceProvider.GetRequiredService<ContactContext>(),
        scope.ServiceProvider.GetRequiredService<VideoGameContext>()
    };

    foreach (var context in contexts)
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
app.UseSwaggerUi();
app.UseOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
