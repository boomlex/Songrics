using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Songrics.Data.Common;
using Songrics.Data.Models;
using Songrics.Services.Models.Lyrics;
using System.Linq;
using Songrics.Services.Mapping;
using Songrics.Services.Models.Home;

namespace Songrics.Services.DataServices
{
    public class LyricsService : ILyricsService
    {
        private readonly IRepository<Lyric> lyricRepository;
        private readonly IRepository<Category> categoriesRepository;

        public LyricsService(
            IRepository<Lyric> lyricRepository,
            IRepository<Category> categoriesRepository)
        {
            this.lyricRepository = lyricRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<IndexLyricViewModel> PostLyric(int count)
        {
            var lyrics = this.lyricRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .To<IndexLyricViewModel>()
                .Take(count).ToList();
            return lyrics;
        }

        public int GetCount()
        {
            return this.lyricRepository.All().Count();
        }

        public async Task<int> Create(string title, string artistName, string albumName, int categoryId, string videoLink, string songLyric)
        {
            var lyric = new Lyric
            {
                Title = title,
                ArtistName = artistName,
                AlbumName = albumName,
                CategoryId = categoryId,
                VideoLink = videoLink,
                SongLyric = songLyric

            };

            await this.lyricRepository.AddAsync(lyric);
            await this.lyricRepository.SaveChangesAsync();

            return lyric.Id;
        }

        public TViewModel GetLyricById<TViewModel>(int id)
        {
            var lyric = this.lyricRepository.All().Where(x => x.Id == id)
                .To<TViewModel>().FirstOrDefault();
            return lyric;
        }

        public IEnumerable<LyricSimpleViewModel> GetAllByCategory(int categoryId)
            => this.lyricRepository
                .All()
                .Where(j => j.CategoryId == categoryId)
                .To<LyricSimpleViewModel>();


        public bool AddRatingToLyric(int lyricId, int rating)
        {
            var lyric = this.lyricRepository.All().FirstOrDefault(j => j.Id == lyricId);
            if (lyric != null)
            {
                lyric.Rating += rating;
                this.lyricRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
