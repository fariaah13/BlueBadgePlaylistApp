using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Song
{
    public class SongListItem
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        [Display (Name = "Artist")]
        public int ArtistID { get; set; }
        [Display (Name = "Album")]
        public int AlbumID { get; set; }

    }
}
