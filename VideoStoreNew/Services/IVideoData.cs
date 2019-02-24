using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreNew.Models;

namespace VideoStoreNew.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();
    }
}
