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
                    .Select(song =>
                    new SongListItem
                    {
                        SongID = song.SongID,
                        Title = song.Title,
                        ArtistName = song.Artist.Name,
                        AlbumName = song.Album.AlbumName
                    });
                return query.ToArray();
            }
        }

        //CreateSong
        //public bool CreateArtist(SongCreate model)
        //{
            //var artist = new Song()
            //{
            //    Title = model.title,
            //    Genre = model.genre,
            //    Artist = model.artist,
            //    Album = model.album,
            //    Runtime = model.runtime,
            //    Language = model.language
            //};

            //using (var ctx = new ApplicationDbContext())
            //{
            //    ctx.Songs.Add(Song);
            //    return ctx.SaveChanges() == 1;
            //}
        }

    }

