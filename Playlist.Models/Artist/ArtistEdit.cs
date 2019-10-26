using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Artist
{
    public class ArtistEdit
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        [Display (Name = "Band")]
        public bool IsBand { get; set; }

        [Display(Name = "Country of Origin")]
        public string CountryOfOrigin { get; set; }
    }
}
