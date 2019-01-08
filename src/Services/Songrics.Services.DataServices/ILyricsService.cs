using System.Collections.Generic;
using System.Threading.Tasks;
using Songrics.Data.Models;

namespace Songrics.Services.DataServices
{
    public interface ILyricsService
    {
        IEnumerable<Lyric> PostLyric(int count);

        Task<int> Create(string title, string artistName , string albumName, string videoLink, string songLyric);
    }
}