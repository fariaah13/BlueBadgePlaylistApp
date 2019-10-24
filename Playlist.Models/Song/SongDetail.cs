﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Models.Song
{
    public class SongDetail
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ArtistID { get; set; }
        public int AlbumID { get; set; }
        public int Runtime { get; set; }
        public string Language { get; set; }
    }
}
