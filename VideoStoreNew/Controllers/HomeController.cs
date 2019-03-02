using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStoreNew.Entities;
using VideoStoreNew.ViewModels;

using VideoStoreNew.Services;

namespace VideoStoreNew.Controllers
{
    public class HomeController : Controller
    {
        //A private variable to hold the Db context, which is a IVideoData type
        private IVideoData _videos;
        public HomeController(IVideoData videos)
        {
            //Assigns the IVideoData object, which is the DB context to the private vareiable on instantiaon
            _videos = videos;
        }
        public ViewResult index()
        {
            var model = _videos.GetAll().Select(video =>
                new VideoViewModel
                {
                    Id = video.Id,
                    Title = video.Title,
                    Genre = video.Genre.ToString()
                });

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _videos.Get(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(new VideoViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Genre = model.Genre.ToString()
            });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var video = new Video
                {
                    Title = model.Title,
                    Genre = model.Genre
                };
                _videos.Add(video);
                _videos.Commit();
                return RedirectToAction("Details", new { id = video.Id });
            }
            
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = _videos.Get(id);

            if (video == null)
                return RedirectToAction("Index");

            return View(video);

        }

        [HttpPost]
        public IActionResult Edit(int id, VideoEditViewModel model)
        {
            //Fetch the Video mathcing the passed in Id and store it in the vaiable vide (using the methods from the context object)
            var video = _videos.Get(id);
            //Checks if the video is null or the model state is invalid and returns the view with the model if either are true
            if(video == null || !ModelState.IsValid)
            {
                return View(model);
            }
            //assign the title and model values from the model to the video object 
            video.Title = model.Title;
            video.Genre = model.Genre;
            //Add a new method called Commit to IVideoData that saves changes to the DB. 
            //EF keeps track of any changes to the DB context and you dont have to pass a video object to the commit method
            _videos.Commit();

            return RedirectToAction("Details", new { id = video.Id });
        }
    }
}
