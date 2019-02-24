using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreNew.Models;

namespace VideoStoreNew.Services
{
    public class MockVideoData : IVideoData
    {
        private IEnumerable<Video> _videos;
        public MockVideoData()
        {
            _videos = new List<Video>
            {
                new Video {Id =1, Title = "Shrek"},
                new Video {Id =1, Title = "Lion King"},
                new Video {Id =1, Title = "Frozen"}
            };
        }
        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }
    }
}
