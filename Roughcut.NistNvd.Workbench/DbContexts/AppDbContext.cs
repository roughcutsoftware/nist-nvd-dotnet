using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roughcut.NistNvd.Workbench.DbModels;
//using Roughcut.NistNvd.Workbench.DbModels;
using Roughcut.NistNvd.Workbench.XmlModels;

namespace Roughcut.NistNvd.Workbench.DbContexts
{
    public class AppDbContext : DbContext
    {

        //public DbSet<CpeItem> CpeItems { get; set; }
        public DbSet<CpeItem> CpeItems { get; set; }

        public AppDbContext()
        {
            
        }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0");
        }
    }
}
