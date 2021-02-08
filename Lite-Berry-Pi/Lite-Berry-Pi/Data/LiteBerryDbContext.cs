using Lite_Berry_Pi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Data
{
    public class LiteBerryDbContext : DbContext
    {
        public LiteBerryDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDesign>().HasKey(
                x => new { x.UserId, x.DesignId }
                );

        }
    }


}
