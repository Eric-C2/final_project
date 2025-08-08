namespace final_project.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class VideoGame
    {
        public int Id { get; set; }
        public string? GameName { get; set; }
        public int PublisherId { get; set; }
        public string? Developer { get; set; }
        public int? ReleaseYear { get; set; }
    }
}