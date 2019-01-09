using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Common;

namespace Songrics.Data.Models
{
    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Lyrics = new HashSet<Lyric>();
        }

        public string Name { get; set; }

        public virtual ICollection<Lyric> Lyrics { get; set; }
    }
}
