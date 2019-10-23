using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Data
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }
        public int Runtime { get; set; }
        public string Language { get; set; }
    }
}
