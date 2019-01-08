using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Songrics.Data.Common;
using Songrics.Data.Models;
using Songrics.Services.Models.Lyrics;
using System.Linq;
using Songrics.Services.Models.Home;

namespace Songrics.Services.DataServices
{
    public class LyricsService : ILyricsService
    {
        private readonly IRepository<Lyric> lyricRepository;

        public LyricsService(IRepository<Lyric> lyricRepository)
        {
            this.lyricRepository = lyricRepository;
        }

        public IEnumerable<IndexLyricViewModel> PostLyric(int count)
        {
            var lyrics = this.lyricRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(
                    x => new IndexLyricViewModel
                    {
                        Id = x.id,
                        Title = x.Title,
                        ArtistName = x.ArtistName,
                        AlbumName = x.AlbumName,
                        VideoLink = x.VideoLink,
                        SongLyric = x.SongLyric,

                    }).Take(count).ToList();
            return lyrics;
        }

        public async Task<int> Create(string title, string artistName, string albumName, string videoLink, string songLyric)
        {
            //TODO: Validate data

            var lyric = new Lyric
            {
                
                Title = title,
                ArtistName = artistName,
                AlbumName = albumName,
                VideoLink = videoLink,
                SongLyric = songLyric,
            };
            await this.lyricRepository.AddAsync(lyric);
            await this.lyricRepository.SaveChangesAsync();

            return lyric.id;
        }

        public LyricDetailsViewModel GetLyricById(int id)
        {
            var lyric = this.lyricRepository.All().Where(x => x.id == id).Select(x => new LyricDetailsViewModel
            {
                
                Title = x.Title,
                ArtistName = x.ArtistName,
                AlbumName = x.AlbumName,
                VideoLink = x.VideoLink,
                SongLyric = x.SongLyric,

            }).FirstOrDefault();
            return lyric;
        }
    }
}
