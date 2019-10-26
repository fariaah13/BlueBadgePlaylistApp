using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Data
{
    public class SongPlaylist
    {
        [Key]
        public int SongPlaylistID { get; set; }

        [ForeignKey("NewPlaylist")]
        [Display (Name ="Playlist")]
        public int NewPlaylistID { get; set; }
        public virtual NewPlaylist NewPlaylist { get; set; }

        [ForeignKey("Song")]
        [Display (Name = "Song")]
        public int SongID { get; set; }
        public virtual Song Song { get; set; }
    }
}
