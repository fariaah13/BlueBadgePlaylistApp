using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playlist.Models.Song;

namespace Playlist.Models.Playlist
{
    public class PlaylistDetail
    {
        public int NewPlaylistID { get; set; }
        public List<SongListItem> Songs { get; set; }
        public string Name { get; set; }

    }
}
