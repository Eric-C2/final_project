namespace final_project.Data;
using final_project.Models;
using final_project.Interfaces;
using System.Linq;

public class VideoGameContextDAO : IVideoGame
{
    public VideoGameContext _context;

    public VideoGameContextDAO(VideoGameContext context)
    {
        _context = context;
    }

    public VideoGame? GetVideoGame(int? id)
    {
        return _context.VideoGames.Where(x => x.Id.Equals(id)).FirstOrDefault();
    }

    public List<VideoGame> First5VideoGames()
    {
        return _context.VideoGames.Take(5).ToList();
    }

    public int? AddVideoGame(VideoGame game)
    {
        try
        {
            _context.VideoGames.Add(game);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public int? DeleteVideoGame(int id)
    {
        var game = this.GetVideoGame(id);

        if (game == null)
            return null;

        try
        {
            _context.VideoGames.Remove(game);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public int? UpdateVideoGame(VideoGame game)
    {
        var gameToUpdate = this.GetVideoGame(game.Id);
        if (gameToUpdate == null)
            return null;

        gameToUpdate.GameName    = game.GameName;
        gameToUpdate.Developer   = game.Developer;
        gameToUpdate.ReleaseYear = game.ReleaseYear;
        gameToUpdate.PublisherId = game.PublisherId;

        try
        {
            _context.VideoGames.Update(gameToUpdate);
            _context.SaveChanges();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}