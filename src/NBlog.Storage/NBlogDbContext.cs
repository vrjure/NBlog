using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NBlog.Storage
{
    public class NBlogDbContext : DbContext
    {
        public NBlogDbContext(DbContextOptions<NBlogDbContext> option) : base(option)
        {

        }

        public DbSet<SiteInfoEntity>? SiteInfo { get; set; }
        public DbSet<ProfileEntity>? Profile { get; set; }
        public DbSet<PostEntity>? Posts { get; set; }
    }
}
