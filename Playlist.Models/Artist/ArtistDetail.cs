using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Artist
{
    public class ArtistDetail
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public bool IsBand { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
