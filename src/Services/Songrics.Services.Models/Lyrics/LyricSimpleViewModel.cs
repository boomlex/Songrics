using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Models;
using Songrics.Services.Mapping;

namespace Songrics.Services.Models.Lyrics
{
    public class LyricSimpleViewModel : IMapFrom<Lyric>
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
