using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Album
{
    public class AlbumCreate
    {
        [Display (Name = "Album Name")]
        public string AlbumName { get; set; }
        [Display (Name = "Album Art")]
        public string AlbumArt { get; set; }
    }
}
