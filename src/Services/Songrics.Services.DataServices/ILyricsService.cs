using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Songrics.Data.Models;
using Songrics.Services.Models.Home;
using Songrics.Services.Models.Lyrics;
using Songrics.Data;

namespace Songrics.Services.DataServices
{
    public interface ILyricsService
    {
       //IEnumerable<IndexLyricViewModel> PostLyric(int count);
       //
       //int GetCount();
       //
       //// Task<int> Create(string title, string artistName, string albumName, int category, string videoLink, string songLyric);
       //
       //TViewModel GetLyricById<TViewModel>(int Id);
       //
       //// IEnumerable<LyricSimpleViewModel> GetAllByCategory(int category);
       //
       //bool AddRatingToLyric(int lyricId, int rating);


        IQueryable<Lyric> All();

        IQueryable<Lyric> allLyrics();

        IQueryable<Lyric> allLyricsById();

        IQueryable<Lyric> GetLyricsId(int id);
    }

}