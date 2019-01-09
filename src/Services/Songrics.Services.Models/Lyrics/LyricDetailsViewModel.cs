using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Models;
using Songrics.Services.Mapping;

namespace Songrics.Services.Models.Lyrics
{
    public class LyricDetailsViewModel : IMapFrom<Lyric>
    {
        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public string VideoLink { get; set; }

        public string SongLyric { get; set; }
    }
}
