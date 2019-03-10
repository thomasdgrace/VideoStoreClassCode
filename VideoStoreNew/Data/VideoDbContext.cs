using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoStoreNew.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VideoStoreNew.Data
{
    public class VideoDbContext : IdentityDbContext<User> 
    {
        public DbSet<Video> Videos { get; set; }

        public VideoDbContext(DbContextOptions<VideoDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    

    }
}
