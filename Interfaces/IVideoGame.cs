using final_project.Models;

namespace final_project.Interfaces
{
    public interface IVideoGame
    {
        VideoGame? GetVideoGame(int? id);

        List<VideoGame> First5VideoGames();

        int? AddVideoGame(VideoGame game);

        int? DeleteVideoGame(int id);

        int? UpdateVideoGame(VideoGame game);
    }
}