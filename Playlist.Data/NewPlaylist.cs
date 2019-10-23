using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Data
{
    public class NewPlaylist
    {
        [Key]
        public int NewPlaylistID { get; set; }
        public string PlaylistName { get; set; }
    }
}
