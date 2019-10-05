using Playlist.Data;
using Playlist.Models.Artist;
using PlaylistApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Services
{
    public class ArtistService
    {
        private readonly int _artistID;

        public ArtistService(int artistID)
        {
            _artistID = artistID;
        }

        //CreateArtist
        public bool CreateArtist(ArtistCreate model)
        {
            var artist = new Artist()
            {
                ArtistID = _artistID,
                Name = model.Name,
                IsBand = model.IsBand,
                CountryOfOrigin = model.CountryOfOrigin
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(artist);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get ALL artist
        public IEnumerable<ArtistListItem> GetAllArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.
                   Artists
                   .Select(
                       artist =>
                            new ArtistListItem
                            {
                                ArtistID = artist.ArtistID,
                                Name = artist.Name,
                                CountryOfOrigin= artist.CountryOfOrigin
                            });
                return query.ToArray();
            }
        }
        //Get Artist --> See all existing artists
        public IEnumerable<ArtistListItem> GetArtistsByID()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Artists
                    .Where(artist => artist.ArtistID == _artistID)
                    .Select(
                     artist =>
                     new ArtistListItem
                     {
                         ArtistID = artist.ArtistID,
                         Name = artist.Name,
                         CountryOfOrigin = artist.CountryOfOrigin
                     }
                    );
                return query.ToArray();
            }
        }
    }
}
