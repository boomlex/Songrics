using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Songrics.Data;
using Songrics.Data.Models;

namespace Songrics.Services.Data
{
    public class LyricsServices : ILyricsServices
    {
        private readonly SongricsContext songricsContext;


        public LyricsServices(SongricsContext songricsContext)
        {
            this.songricsContext = songricsContext;
            this.songricsContext = songricsContext;
        }

        public IQueryable<Lyric> All() => this.songricsContext.Lyrics;


        public IQueryable<Lyric> allLyrics()
        {
            return this.All();
        }

        public IQueryable<Lyric> allLyricsById()
        {
            return this.All().OrderBy(n => n.Id);
        }

        public IQueryable<Lyric> GetLyricId(int id)
        {
            return this.allLyricsById().Where(n => n.Id == id);
        }

    }
}
