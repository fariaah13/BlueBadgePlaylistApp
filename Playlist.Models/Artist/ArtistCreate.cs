using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Artist
{
    public class ArtistCreate
    {
        [Required]
        public string Name { get; set; }
        [Display (Name = "Band")]
        public bool IsBand { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string CountryOfOrigin { get; set; }
    }
}
