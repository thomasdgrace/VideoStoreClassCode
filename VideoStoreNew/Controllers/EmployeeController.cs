using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoStoreNew.Controllers
{
    [Route("company/[controller]/[action]")]
    public class EmployeeController :Controller
    {
        [Route("")]
        
        public string Index()
        {
            return "Hello, from Employee";
        }
        
        public ContentResult Name()
        {
            return Content("Jonas");
        }
        
        public string Country()
        {
            return "South Africa";
        }
    }
}
