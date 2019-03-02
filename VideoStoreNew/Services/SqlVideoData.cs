using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreNew.Entities;
using VideoStoreNew.Data;

namespace VideoStoreNew.Services
{
    public class SqlVideoData : IVideoData
    {
        //Holds the context needed to comunicate with DB
        private VideoDbContext _db;

        public SqlVideoData(VideoDbContext db)
        {
            //on cosntruction a Context is passed in and assigned to the private field above 
            _db = db;
        }
        public void Add(Video newVideo)
        {
            _db.Add(newVideo);
            _db.SaveChanges();
        }

        public Video Get(int id)
        {
            return _db.Find<Video>(id);
        }

        public IEnumerable<Video> GetAll()
        {
            return _db.Videos;
        }
    }
}
