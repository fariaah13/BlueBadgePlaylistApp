using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models
{
    public class ArtistListItem
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public bool IsBand { get; set; }
        [Display(Name = "Country")]
        public string CountryOfOrigin { get; set; }
    }
}
