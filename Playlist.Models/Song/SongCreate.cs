using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Song
{
    public class SongCreate
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Runtime { get; set; }
        public string Language { get; set; }
    }
}
