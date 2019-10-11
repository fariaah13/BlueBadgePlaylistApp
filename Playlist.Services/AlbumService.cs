using Playlist.Data;
using Playlist.Models.Album;
using PlaylistApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Services
{
    public class AlbumService
    {
        //CreateAlbum
        public bool CreateAlbum (AlbumCreate model)
        {
            var album = new Album()
            {
                AlbumName = model.AlbumName,
                AlbumArt = model.AlbumArt
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(album);
                return ctx.SaveChanges() == 1;
            }
        }
        
        //GetAllAlbums
        public IEnumerable<AlbumListItem> GetAllAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Albums
                    .Select(albums =>
                    new AlbumListItem
                    {
                        AlbumID = albums.AlbumID,
                        AlbumName = albums.AlbumName,
                        AlbumArt = albums.AlbumArt
                    });
                return query.ToArray();
            }
        }
        
        //GetAlbumByID
        public AlbumDetail GetAlbumByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var album = ctx.Albums
                    .Single(a => a.AlbumID == id);

                return new AlbumDetail
                {
                    AlbumID = album.AlbumID,
                    AlbumName = album.AlbumName,
                    AlbumArt = album.AlbumArt
                };
            }
        }

        //DeleteAlbum
        public bool DeleteAlbum(int albumID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums
                    .Single(album => album.AlbumID == albumID);

                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        
        //EditAlbum
        public bool EditAlbum (AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums
                    .Single(album => album.AlbumID == model.AlbumID);

                entity.AlbumName = model.AlbumName;
                entity.AlbumArt = model.AlbumArt;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
