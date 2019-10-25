using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.SongPlaylist
{
    public class SongPlaylistListItem
    {
        public int SongPlaylistID { get; set; }
        public int NewPlaylistID { get; set; }
        public int SongID { get; set; }
    }
}
