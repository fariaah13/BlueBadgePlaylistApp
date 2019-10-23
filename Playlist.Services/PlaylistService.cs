using Playlist.Data;
using Playlist.Models.Playlist;
using PlaylistApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Services
{
    public class PlaylistService
    {
        //CreatePlaylist
        public bool CreatePlaylist(PlaylistCreate model)
        {
            var playlist = new NewPlaylist()
            {
                PlaylistName = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(playlist);
                return ctx.SaveChanges() == 1;
            }
        }

        //GetAllPlaylists
        public IEnumerable<PlaylistListItems> GetAllPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Playlists
                   .Select(playlist =>
                       new PlaylistListItems
                       {
                           NewPlaylistID = playlist.NewPlaylistID,
                           Name = playlist.PlaylistName,

                       });
                return query.ToArray();
            }
        }

        //GetPlaylistById
        public PlaylistDetail GetPlaylistByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var playlist = ctx.Playlists
                    .Single(e => e.NewPlaylistID == id);

                return new PlaylistDetail
                {
                    NewPlaylistID = playlist.NewPlaylistID,
                    Name = playlist.PlaylistName
                };
            }
        }
        //EditPlaylist
        public bool EditPlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var playlist = ctx.Playlists
                    .Single(e => e.NewPlaylistID == model.NewPlaylistID);

                playlist.PlaylistName = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        //DeletePlaylist
        public bool DeletePlaylist(int playlistID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(playlist => playlist.NewPlaylistID == playlistID);

                ctx.Playlists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

