using final_project.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Nintendo" },
                new Publisher { Id = 2, Name = "Sony Interactive Entertainment" },
                new Publisher { Id = 3, Name = "Electronic Arts" }
            );

            builder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    GameName = "The Legend of Zelda: Breath of the Wild",
                    Developer = "Nintendo",
                    ReleaseYear = 2017,
                    PublisherId = 1
                },
                new VideoGame
                {
                    Id = 2,
                    GameName = "God of War",
                    Developer = "Santa Monica Studio",
                    ReleaseYear = 2018,
                    PublisherId = 2
                }
            );
        }

        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}