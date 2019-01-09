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

        int GetCount();

        Task<int> Create(string title, string artistName, string albumName, int categoryId, string videoLink, string songLyric);

        TViewModel GetLyricById<TViewModel>(int Id);

        IEnumerable<LyricSimpleViewModel> GetAllByCategory(int categoryId);

        bool AddRatingToLyric(int lyricId, int rating);
    }

}