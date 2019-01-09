using Songrics.Data.Models;
using System.Linq;
using Songrics.Data;


namespace Songrics.Services.DataServices
{

    public class LyricsService : ILyricsService
    {


        private SongricsContext songricsContext;


        public LyricsService(SongricsContext songricsContext)
        {
            this.songricsContext = songricsContext;

        }

        public IQueryable<Lyric> All() => this.songricsContext.Receipts;


        public IQueryable<Lyric> allLyrics()
        {
            return this.All();
        }

        public IQueryable<Lyric> allLyricsById()
        {
            return this.All().OrderBy(n => n.Id);
        }

        public IQueryable<Lyric> GetLyricsId(int id)
        {
            return this.allLyricsById().Where(n => n.Id == id);
        }

    }
}
