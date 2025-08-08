using final_project.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TeamMemberContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeamMembersContext")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();

builder.Services.AddScoped<PizzaRestaurantDAO>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TeamMemberContext>();
    dbContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
app.UseSwaggerUi();
app.UseOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
