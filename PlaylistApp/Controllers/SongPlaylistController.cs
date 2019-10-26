using Playlist.Models.SongPlaylist;
using Playlist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaylistApp.Controllers
{
    public class SongPlaylistController : Controller
    {
        // GET: SongPlaylist
        public ActionResult Index()
        {
            var service = new SongPlaylistService();
            var model = service.GetAllSongsInPlaylist();
            return View(model);
        }
        //GET /Create
        public ActionResult Create(int? newPlaylistID)
        {
            var playlist = new PlaylistService();
            ViewBag.NewPlaylistID = (newPlaylistID == null) // Ternary
                ? new SelectList(playlist.GetAllPlaylists().ToList(), "NewPlaylistID", "Name")
                : new SelectList(playlist.GetAllPlaylists().ToList(), "NewPlaylistID", "Name", newPlaylistID);

            var song = new SongService();
            ViewBag.SongID = new SelectList(song.GetAllSongs().ToList(), "SongID", "Title");
            return View();
        }
        //POST /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongPlaylistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SongPlaylistService();

            if (service.AddSongsToPlaylist(model))
            {
                TempData["SaveResult"] = "Song has been added to playlist";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Song was not added to playlist");
            return View(model);
        }
        //GET /Detail
        //GET /Edit
        //public ActionResult Edit(int id)
        //{
        //    var service = new SongPlaylistService();
        //    var detail = service.DeleteSongFromPlaylist(id);
        //    var model =
        //        new SongPlaylistEdit
        //        {
        //            SongID = detail.
                    
        //        };

        //    return View(model);
        //}
        //POST /Edit
        //GET /Delete
        public ActionResult Delete (int id)
        {
            var svc = new SongPlaylistService();
            var model = svc.DeleteSongFromPlaylist(id);

            return View(model);
        }

        //POST /Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSongFromPlaylist(int id)
        {
            var service = new SongPlaylistService();
            service.DeleteSongFromPlaylist(id);
            TempData["SaveResult"] = "Song has been deleted from playlist";
            return RedirectToAction("Index");
        }
    }
}