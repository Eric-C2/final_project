using final_project.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data
{
    public class TeamMemberContext : DbContext
    {
        public TeamMemberContext(DbContextOptions<TeamMemberContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeamMember>().HasData(new TeamMember
            { Id = 1, TeamMemberFullName = "Eric Coomer", 
                BirthDay = new DateTime(1997, 5, 23), 
                CollegeProgram = "Information Technology", 
                YearInProgram = "Junior" });
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<PizzaRestaurant> PizzaRestaurants { get; set; }
    }
}
