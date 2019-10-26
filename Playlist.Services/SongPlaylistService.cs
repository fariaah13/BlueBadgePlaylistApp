using Playlist.Data;
using Playlist.Models.SongPlaylist;
using PlaylistApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Services
{
    public class SongPlaylistService
    {
        //CreateSongPlaylist
        public bool AddSongsToPlaylist(SongPlaylistCreate model)
        {
            var newsong = new SongPlaylist()
            {
                NewPlaylistID = model.NewPlaylistID,
                SongID = model.SongID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlaylistOfSongs.Add(newsong);
                return ctx.SaveChanges() == 1;
            }
        }
        //GetAllSongsInSongPlaylist
        public IEnumerable<SongPlaylistListItem> GetAllSongsInPlaylist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PlaylistOfSongs
                    .Select(songs =>
                    
                    new SongPlaylistListItem
                    {
                        SongPlaylistID = songs.SongPlaylistID,
                        NewPlaylistID = songs.NewPlaylistID,
                        PlaylistName = songs.NewPlaylist.PlaylistName,
                        SongName = songs.Song.Title,
                        SongID = songs.SongID,
                        
                    });
                return query.ToArray();
            }
        }
        //EditSongPlaylist
        public bool EditSongPlaylist(SongPlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var song = ctx.PlaylistOfSongs
                    .Single(s => s.SongPlaylistID == model.SongPlaylistID);

                song.NewPlaylistID = model.NewPlaylistID;
                song.SongID = model.SongID;

                return ctx.SaveChanges() == 1;
            }
        }
        //DeleteSongPlaylist
        public bool DeleteSongFromPlaylist(int songID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var song = ctx.PlaylistOfSongs
                    .Single(s => s.SongID == songID);

                ctx.PlaylistOfSongs.Remove(song);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

