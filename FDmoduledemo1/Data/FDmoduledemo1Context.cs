using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FDmoduledemo1.Models;

namespace FDmoduledemo1.Data
{
    public class FDmoduledemo1Context : DbContext
    {
        public FDmoduledemo1Context (DbContextOptions<FDmoduledemo1Context> options)
            : base(options)
        {
        }

        public DbSet<FDmoduledemo1.Models.AccountUser> AccountUser { get; set; }

        public DbSet<FDmoduledemo1.Models.FDTable> FDTable { get; set; }

        public DbSet<FDmoduledemo1.Models.RD> RD { get; set; }
    }
}
