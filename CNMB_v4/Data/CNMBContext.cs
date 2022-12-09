using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CNMB_v4.Data
{
    public class CNMBContext : DbContext
    {
        public CNMBContext (DbContextOptions<CNMBContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Teacher> Teacher { get; set; } = default!;

        public DbSet<Models.School> School { get; set; }

        public DbSet<Models.Team> Team { get; set; }
    }
}
