using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Common;

namespace Songrics.Data.Models
{
    public class Lyric : BaseModel<int>
    {
        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public int CategoryId { get; set; }

        public double Rating { get; set; }

        public string VideoLink { get; set; }

        public string SongLyric { get; set; }

        public virtual Category Category { get; set; }
    }
}
