using System.ComponentModel.DataAnnotations;
namespace Songrics.Web.Model.Lyric
{
    public class CreateLyricInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string ArtistName { get; set; }

        [Required]
        public string AlbumName { get; set; }

        public string VideoLink { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }

        [Required]
        public string SongLyric { get; set; }
    }
}