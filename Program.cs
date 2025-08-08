using final_project.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var contexts = new DbContext[]
    {
        // add Context files here
        scope.ServiceProvider.GetRequiredService<TeamMemberContext>(),
        scope.ServiceProvider.GetRequiredService<ContactContext>(),
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
