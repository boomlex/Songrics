using System.ComponentModel.DataAnnotations;
using Songrics.Data.Models;
using Songrics.Data.Models.Enums;

namespace Songrics.Web.Model.Lyric
{
    public class CreateLyricInputModel
    {
        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public LyricCategory Category { get; set; }

        public string VideoLink { get; set; }

        public string SongLyric { get; set; }

       // public string UserId { get; set; }

       // public SongricsUser User { get; set; }
    }
}