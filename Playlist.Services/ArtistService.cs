using Playlist.Data;
using Playlist.Models;
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
        //CreatePlaylist
        public bool CreateArtist(ArtistCreate model)
        {
            var artist = new Artist()
            {
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

        //GetAllArtists
        public IEnumerable<ArtistListItem> GetAllArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Artists
                   .Select( artist =>
                        new ArtistListItem
                        {
                            ArtistID = artist.ArtistID,
                            Name = artist.Name,
                            IsBand = artist.IsBand,
                            CountryOfOrigin= artist.CountryOfOrigin
                        });
                return query.ToArray();
            }
        }

        //GetArtistByID
        public ArtistDetail GetArtistByID (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var artist = ctx.Artists
                    .Single(a => a.ArtistID == id);

                return new ArtistDetail
                {
                    ArtistID = artist.ArtistID,
                    Name = artist.Name,
                    IsBand = artist.IsBand,
                    CountryOfOrigin = artist.CountryOfOrigin
                };
            }
        }
        //EditArtist
        public bool EditArtist (ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(artist => artist.ArtistID == model.ArtistID);

                entity.Name = model.Name;
                entity.CountryOfOrigin = model.CountryOfOrigin;
                entity.IsBand = model.IsBand;

                return ctx.SaveChanges() == 1;
            }
        }
        
        //DeleteArtist
        public bool DeleteArtist (int artistID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(artist => artist.ArtistID == artistID);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
