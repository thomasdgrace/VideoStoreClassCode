using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreNew.Entities;
using VideoStoreNew.ViewModels;

namespace VideoStoreNew.Services
{
    public class MockVideoData : IVideoData
    {
        private List<Video> _videos;
        public MockVideoData()
        {
            _videos = new List<Video>
            {
                new Video {Id =1, Title = "Shrek",Genre =ViewModels.Genres.Comedy},
                new Video {Id =2, Title = "Lion King", Genre =ViewModels.Genres.Comedy},
                new Video {Id =3, Title = "Frozen", Genre = ViewModels.Genres.Comedy}
            };
        }

        public void Add(Video newVideo)
        {
            newVideo.Id = _videos.Max(v => v.Id) + 1;
            _videos.Add(newVideo);
        }

        public Video Get(int id)
        {
            return _videos.FirstOrDefault(v => v.Id.Equals(id));
        }

        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }
    }
}
