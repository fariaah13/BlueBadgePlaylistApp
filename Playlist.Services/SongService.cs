using Playlist.Data;
using Playlist.Models.Song;
using PlaylistApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Services
{
    public class SongService
    {
        //GetAllSongs
        public IEnumerable<SongListItem> GetAllSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Songs
                    .Select(songs =>
                    new SongListItem
                    {
                        SongID = songs.SongID,
                        Title = songs.Title,
                        ArtistID = songs.ArtistID,
                        ArtistName = songs.Artist.Name,
                        AlbumID = songs.AlbumID,
                        AlbumName = songs.Album.AlbumName
                    });
                return query.ToArray();
            }
        }

        //CreateSong
        public bool CreateSong(SongCreate model)
        {
            var song = new Song()
            {
                Title = model.Title,
                Genre = model.Genre,
                ArtistID = model.ArtistID,
                AlbumID = model.AlbumID,
                Runtime = model.Runtime,
                Language = model.Language
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(song);
                return ctx.SaveChanges() == 1;
            }
        }

        //GetSongByID
        public SongDetail GetSongByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var song = ctx.Songs
                    .Single(s => s.SongID == id);

                return new SongDetail
                {
                    SongID = song.SongID,
                    Title = song.Title,
                    Genre = song.Genre,
                    ArtistID = song.ArtistID,
                    AlbumID = song.AlbumID,
                    Runtime = song.Runtime,
                    Language = song.Language
                };
            }
        }

        //DeleteSong
        public bool DeleteSong(int songID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var song = ctx.Songs
                    .Single(s => s.SongID == songID);

                ctx.Songs.Remove(song);

                return ctx.SaveChanges() == 1;
            }
        }

        //EditSong
        public bool EditSong (SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var song = ctx.Songs
                    .Single(s => s.SongID == model.SongID);

                song.Title = model.Title;
                song.Genre = model.Genre;
                song.ArtistID = model.ArtistID;
                song.AlbumID = model.AlbumID;
                song.Runtime = model.Runtime;
                song.Language = model.Language;

                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}

