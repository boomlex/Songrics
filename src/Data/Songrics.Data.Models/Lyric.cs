using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Common;

namespace Songrics.Data.Models
{
    public class Lyric : BaseModel<int>
    {
        public string Title { get; set; }

        public string SongLyric { get; set; }

        public string TypeLyric { get; set; }

        public int ContentId { get; set; }

        public virtual Category Category { get; set; }
    }
}
