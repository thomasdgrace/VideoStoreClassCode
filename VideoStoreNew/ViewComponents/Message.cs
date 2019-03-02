using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreNew.Services;

namespace VideoStoreNew.ViewComponents
{
    public class Message : ViewComponent
    {
        //Private variable to hold the serivce and the contructor that accepts the service 
        private IMessageService _message;
        public Message(IMessageService message)
        {
            _message = message;
        }
        //Invoke returns a IViewComponent, this creates a variable to hold the message from the service (Get message)
        public IViewComponentResult Invoke()
        {
            var model = _message.GetMessage();
            return View("Default", model);
        }
    }
}
