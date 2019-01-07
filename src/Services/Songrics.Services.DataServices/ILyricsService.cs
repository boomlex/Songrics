using System.Collections.Generic;
using Songrics.Data.Models;
using Songrics.Services.Models.Lyric;

namespace Songrics.Services.DataServices
{
    public interface ILyricsService
    {
        IEnumerable<Lyric> PostLyric(int count);

        int Create(CreateLyricInputModel input);
    }
}