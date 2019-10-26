using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.SongPlaylist
{
    public class SongPlaylistCreate
    {
        public int SongPlaylistID { get; set; }
        [Display (Name = "Playlist")]
        public int NewPlaylistID { get; set; }
        [Display (Name = "Song")]
        public int SongID { get; set; }
    }
}
