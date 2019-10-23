//using Playlist.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace PlaylistApp.Controllers
//{
//    public class SongController : Controller
//    {
//        // GET: Song
//        public ActionResult Index()
//        {
//            var service = new SongService();
//            var model = service.GetAllSongs();
//            return View(model);
//        }

//        //GET Song/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        //POST Song/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(SongCreate model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            var service = new SongService();

//            if (service.CreateSong(model))
//            {
//                TempData["SaveResult"] = "Song has been added";
//                return RedirectToAction("Index");
//            }

//            ModelState.AddModelError("", "Song was not added");
//            return View(model);
//        }
//        //GET Song/Detail
//        public ActionResult Details(int id)
//        {
//            var svc = new SongService();
//            var model = svc.GetSongByID(id);

//            return View(model);
//        }
//        //GET Song/Edit
//        public ActionResult Edit(int id)
//        {
//            var service = new SongService();
//            var detail = service.GetSongByID(id);
//            var model =
//                new SongEdit
//                {

//                };
//            return View(model);
//        }
//        //POST Song/Edit
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, SongEdit model)
//        {
//            if (!ModelState.IsValid) return View(model);

//            if (model.SongID != id)
//            {
//                ModelState.AddModelError("", "ID Mismatch");
//                return View(model);
//            }

//            var service = new SongService();
//            if (service.EditSong(model))
//            {
//                TempData["SaveResult"] = "Song was updated";
//                return RedirectToAction("Index");
//            }
//            ModelState.AddModelError("", "Song could not be updated");
//            return View();
//        }

//        //GET Song/Delete
//        public ActionResult Delete(int id)
//        {
//            var svc = new SongService();
//            var model = svc.GetSongByID(id);

//            return View(model);

//        }

//        //POST Song/Delete
//        [HttpPost]
//        [ActionName("Delete")]
//        [ValidateAntiForgeryToken]

//        public ActionResult DeleteSong(int id)
//        {
//            var service = new SongService();
//            service.DeleteSong(id);
//            TempData["SaveResult"] = "Song was deleted";
//            return RedirectToAction("Index");
//        }
//    }
//}