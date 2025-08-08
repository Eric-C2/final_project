using final_project.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().HasData(new Contact
            {
                Id                  = 1,
                ContactFirstName    = "Eric",
                ContactLastName     = "Coomer",
                ContactCountryCode  = 1,
                ContactPhoneNumber  = "513-123-1234" 
            });
        }
        public DbSet<Contact> Contacts {get; set; }
    }
}
