using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Data
{
    public class SongPlaylist
    {
        [Key]
        public int SongPlaylistID { get; set; }
        public int ArtistID { get; set; }
        public int SongID { get; set; }
    }
}
