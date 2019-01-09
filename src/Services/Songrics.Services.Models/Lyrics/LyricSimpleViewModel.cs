using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Models;
using Songrics.Data.Models.Enums;
using Songrics.Services.Mapping;

namespace Songrics.Services.Models.Lyrics
{
    public class LyricSimpleViewModel : IMapFrom<Lyric>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public string VideoLink { get; set; }

        public LyricCategory Category { get; set; }

        public string SongLyric { get; set; }
    }
}
