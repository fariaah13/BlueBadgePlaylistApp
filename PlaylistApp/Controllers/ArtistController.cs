using Microsoft.AspNet.Identity;
using Playlist.Data;
using Playlist.Models.Artist;
using Playlist.Services;
using PlaylistApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PlaylistApp.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            var service = new ArtistService();
            var model = service.GetAllArtists();
            return View(model);
        }

        //GET Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ArtistService();

            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Artist has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Artist was not added");
            return View(model);
        }
        //GET Artist/Detail
        public ActionResult Details(int id)
        {
            var svc = new ArtistService();
            var model = svc.GetArtistByID(id);

            return View(model);
        }
        //GET Artist/Edit
        public ActionResult Edit(int id)
        {
            var service = new ArtistService();
            var detail = service.GetArtistByID(id);
            var model =
                new ArtistEdit
                {
                    ArtistID = detail.ArtistID,
                    Name = detail.Name,
                    CountryOfOrigin = detail.CountryOfOrigin,
                    IsBand = detail.IsBand
                };
            return View(model);
        }
        //POST Artist/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtistID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = new ArtistService();
            if (service.EditArtist(model))
            {
                TempData["SaveResult"] = "Artist was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Artist could not be updated");
            return View();
        }

        //GET Artist/Delete
        public ActionResult Delete (int id)
        {
            var svc = new ArtistService();
            var model = svc.GetArtistByID(id);

            return View(model);

        }
        
        //POST Artist/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteArtist (int id)
        {
            var service = new ArtistService();
            service.DeleteArtist(id);
            TempData["SaveResult"] = "Artist has been deleted";
            return RedirectToAction("Index");
        }
    }
}