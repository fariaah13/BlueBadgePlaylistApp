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
            var service = new ArtistService(artistID); //How fix???
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
            if (!ModelState.IsValid) return View(model);
            var service = CreateArtistService();
            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Artist has been added";
                return RedirectToAction("Index");
            }
        }
        //GET Artist/Detail
        //GET Artist/Edit
        //POST Artist/Edit
        //GET Artist/Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistByID(id);
        }
        //POST Artist/Delete
        

        private ArtistService CreateArtistService()
        {
            var service = new ArtistService(artistID);
            return Service;
        }
    }
}