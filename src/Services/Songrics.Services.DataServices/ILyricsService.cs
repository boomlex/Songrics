using System.Collections.Generic;
using System.Threading.Tasks;
using Songrics.Data.Models;
using Songrics.Services.Models.Home;
using Songrics.Services.Models.Lyrics;

namespace Songrics.Services.DataServices
{
    public interface ILyricsService
    {
        IEnumerable<IndexLyricViewModel> PostLyric(int count);

        Task<int> Create(string title, string artistName , string albumName, string videoLink, string songLyric);

        LyricDetailsViewModel GetLyricById(int Id);
    }
}