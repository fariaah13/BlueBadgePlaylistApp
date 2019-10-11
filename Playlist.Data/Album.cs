using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Data
{
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        [Required]
        public string AlbumName { get; set; }
        [Required]
        public string AlbumArt { get; set; } 
    }
}
