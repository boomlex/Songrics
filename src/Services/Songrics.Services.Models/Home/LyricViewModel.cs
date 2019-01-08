using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Songrics.Data.Models;
using Songrics.Services.Mapping;

namespace Songrics.Services.Models.Home
{
    public class IndexLyricViewModel:IMapFrom<Lyric>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public string VideoLink { get; set; }

        public string SongLyric { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            // configuration.CreateMap<Joke, IndexJokeViewModel>().ForMember(x => x.CategoryName, x => x.MapFrom(j => j.Category.Name))
        }
    }
}
