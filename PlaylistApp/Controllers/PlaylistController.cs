using Playlist.Models.Playlist;
using Playlist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaylistApp.Controllers
{
    public class PlaylistController : Controller
    {
        // GET: Playlist
        public ActionResult Index()
        {
            var service = new PlaylistService();
            var model = service.GetAllPlaylists();
            return View(model);
        }
        //GET Playlist/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST Playlist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new PlaylistService();

            if (service.CreatePlaylist(model))
            {
                TempData["SaveResult"] = "Playlist has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Playlist was not added");
            return View(model);
        }
        //GET Playlist/Detail
        public ActionResult Details(int id)
        {
            var svc = new PlaylistService();
            var model = svc.GetPlaylistByID(id);

            return View(model);
        }
        //GET Playlist/Edit
        public ActionResult Edit(int id)
        {
            var service = new PlaylistService();
            var detail = service.GetPlaylistByID(id);
            var model =
                new PlaylistEdit
                {
                    NewPlaylistID = detail.NewPlaylistID,
                    Name = detail.Name
                };

            return View(model);
        }
        //POST Playlist/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlaylistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NewPlaylistID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = new PlaylistService();
            if (service.EditPlaylist(model))
            {
                TempData["SaveResult"] = "Playlist was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Playlist could not be updated");
            return View();
        }

        //GET Playlist/Delete
        public ActionResult Delete(int id)
        {
            var svc = new PlaylistService();
            var model = svc.GetPlaylistByID(id);

            return View(model);
        }
        //POST Playlist/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeletePlaylist(int id)
        {
            var service = new PlaylistService();
            service.DeletePlaylist(id);
            TempData["SaveResult"] = "Playlist was deleted";
            return RedirectToAction("Index");
        }

    }
}