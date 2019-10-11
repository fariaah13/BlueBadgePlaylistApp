using Playlist.Models.Album;
using Playlist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaylistApp.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            var service = new AlbumService();
            var model = service.GetAllAlbums();
            return View(model);
        }

        //GET Album/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new AlbumService();

            if (service.CreateAlbum(model))
            {
                TempData["SaveResult"] = "Album has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Album was not added");
            return View(model);
        }
        //GET Album/Detail
        public ActionResult Details (int id)
        {
            var svc = new AlbumService();
            var model = svc.GetAlbumByID(id);

            return View(model);
        }

        //GET Album/Edit
        public ActionResult Edit (int id)
        {
            var service = new AlbumService();
            var detail = service.GetAlbumByID(id);
            var model =
                new AlbumEdit
                {
                    AlbumID = detail.AlbumID,
                    AlbumName = detail.AlbumName,
                    AlbumArt = detail.AlbumArt
                };

            return View(model);
        }
        //POST Album/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlbumEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AlbumID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = new AlbumService();
            if (service.EditAlbum(model))
            {
                TempData["SaveResult"] = "Album was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Album could not be updated");
            return View();
        }
        //GET Album/Delete
        public ActionResult Delete (int id)
        {
            var svc = new AlbumService();
            var model = svc.GetAlbumByID(id);

            return View(model);
        }
        
        //POST Album/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAlbum (int id)
        {
            var service = new AlbumService();
            service.DeleteAlbum(id);
            TempData["SaveResult"] = "Album was deleted";
            return RedirectToAction("Index");
        }
    }
}