using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStoreNew.Models;

using VideoStoreNew.Services;

namespace VideoStoreNew.Controllers
{
    public class HomeController: Controller
    {
        private IVideoData _videos;
        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }
        public ViewResult index()
        {
            var model = _videos.GetAll();
           
            return View(model);
        }
    }
}
