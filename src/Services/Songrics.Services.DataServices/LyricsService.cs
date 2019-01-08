using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Songrics.Data.Common;
using Songrics.Data.Models;

namespace Songrics.Services.DataServices
{
    public class LyricsService : ILyricsService
    {
        private readonly IRepository<Lyric> lyricRepository;

        public LyricsService(IRepository<Lyric> lyricRepository)
        {
            this.lyricRepository = lyricRepository;
        }

        public IEnumerable<Lyric> PostLyric(int count)
        {
            //TODO: Add logic for adding a lyric
            throw new Exception();
        }

        public async Task<int> Create(string title, string artistName , string albumName, string videoLink, string songLyric)
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
    }
}
