using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Models;
using Songrics.Data.Models.Enums;
using Songrics.Services.Mapping;

namespace Songrics.Services.Models.Home
{
   public class IndexLyricViewModel:IMapFrom<Lyric>
   {
        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public LyricCategory Category { get; set; }

        public string VideoLink { get; set; }

        public string SongLyric { get; set; }

        public string UserId { get; set; }

        public SongricsUser User { get; set; }
    }
}
