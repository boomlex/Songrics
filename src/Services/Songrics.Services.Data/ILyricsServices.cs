using System.Linq;
using Songrics.Data.Models;

namespace Songrics.Services.Data
{
    public interface ILyricsServices
    {
        IQueryable<Lyric> All();

        IQueryable<Lyric> allLyrics();

        IQueryable<Lyric> allLyricsById();

        IQueryable<Lyric> GetLyricId(int id);
    }
}