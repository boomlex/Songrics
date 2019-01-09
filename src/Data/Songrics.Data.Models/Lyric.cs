using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Common;
using Songrics.Data.Models.Enums;

namespace Songrics.Data.Models
{
    public class Lyric : BaseModel<int>
    {
        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public LyricCategory Category { get; set; }

        public double Rating { get; set; }

        public string VideoLink { get; set; }

        public string SongLyric { get; set; }

        public string UserId { get; set; }

        public SongricsUser User { get; set; }
    }
}
