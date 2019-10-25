using Playlist.Models.Song;
using Playlist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaylistApp.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            var service = new SongService();
            var model = service.GetAllSongs();
            return View(model);
        }

        //GET /Create
        public ActionResult Create()
        {
            var artist = new ArtistService();
            ViewBag.ArtistID = new SelectList(artist.GetAllArtists().ToList(), "ArtistID", "Name");

            var album = new AlbumService();
            ViewBag.AlbumID = new SelectList(album.GetAllAlbums().ToList(), "AlbumID", "AlbumName");
            return View();
        }

        //POST /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SongService();

            if (service.CreateSong(model))
            {
                TempData["SaveResult"] = "Song has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Song was not added");
            return View(model);
        }
        //GET /Detail
        public ActionResult Details(int id)
        {
            var svc = new SongService();
            var model = svc.GetSongByID(id);

            return View(model);
        }
        //GET /Edit
        public ActionResult Edit(int id)
        {
            var service = new SongService();
            var detail = service.GetSongByID(id);
            var model =
                new SongEdit
                {
                    Title = detail.Title,
                    Genre = detail.Genre,
                    ArtistID = detail.ArtistID,
                    AlbumID = detail.AlbumID,
                    Runtime = detail.Runtime,
                    Language = detail.Language
                };
            return View(model);
        }
        //POST /Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SongEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SongID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = new SongService();
            if (service.EditSong(model))
            {
                TempData["SaveResult"] = "Song was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Song could not be updated");
            return View();
        }
        //GET /Delete
        public ActionResult Delete(int id)
        {
            var svc = new SongService();
            var model = svc.GetSongByID(id);

            return View(model);
        }
        //POST /Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSong(int id)
        {
            var service = new SongService();
            service.DeleteSong(id);
            TempData["SaveResult"] = "Song has been deleted";
            return RedirectToAction("Index");
        }
    }
}