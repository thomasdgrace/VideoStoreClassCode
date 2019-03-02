﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreNew.Entities;

namespace VideoStoreNew.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();

        Video Get(int id);

        void Add(Video newVideo);

        int Commit();
    }
}
