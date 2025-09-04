using Heroes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Infrastructure.Context
{
    public class HeroesContext : DbContext
    {
        public DbSet<HeroiEntity> Herois { get; set; }
        public DbSet<SuperpoderEntity> Superpoderes { get; set; }
        public DbSet<HeroisSuperpoderesEntity> HeroisSuperpoderes { get; set; }

        public HeroesContext(DbContextOptions<HeroesContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HeroisSuperpoderesEntity>()
                .HasKey(hs => new { hs.HeroiId, hs.SuperpoderId });

            modelBuilder.Entity<HeroisSuperpoderesEntity>()
                .HasOne(hs => hs.Heroi)
                .WithMany(h => h.HeroisSuperpoderes)
                .HasForeignKey(hs => hs.HeroiId);

            modelBuilder.Entity<HeroisSuperpoderesEntity>()
                .HasOne(hs => hs.Superpoder)
                .WithMany(s => s.HeroisSuperpoderes)
                .HasForeignKey(hs => hs.SuperpoderId);
        }
    }

}
