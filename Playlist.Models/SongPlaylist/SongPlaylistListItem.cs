using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.SongPlaylist
{
    public class SongPlaylistListItem
    {
        public int SongPlaylistID { get; set; }

        public string PlaylistName { get; set; }
        [Display (Name = "Playlist")]
        public int NewPlaylistID { get; set; }

        public string SongName { get; set; }
        [Display(Name = "Song")]
        public int SongID { get; set; }
    }
}
