using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Song
{
    public class SongCreate
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        [Display (Name  = "Artist")]
        public int ArtistID { get; set; }
        [Display (Name = "Album")]
        public int AlbumID { get; set; }
        public int Runtime { get; set; }
        public string Language { get; set; }
    }
}
