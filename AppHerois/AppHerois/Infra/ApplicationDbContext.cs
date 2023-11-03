using AppHerois.Models;
using Microsoft.EntityFrameworkCore;

namespace AppHerois.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HeroiModel> Herois { get; set; }
        public DbSet<SuperPoderesModel> SuperPoderes { get; set; }
        public DbSet<HeroisSuperpoderesModel> HeroisPoderes { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HeroiModel>().Property(p => p.Nome).IsRequired();
            modelBuilder.Entity<HeroiModel>().Property(p => p.Nome).HasMaxLength(120);
            modelBuilder.Entity<HeroiModel>().Property(p => p.NomeHeroi).IsRequired();
            modelBuilder.Entity<HeroiModel>().Property(p => p.NomeHeroi).HasMaxLength(120);

            modelBuilder.Entity<SuperPoderesModel>().Property(p => p.SuperPoder).IsRequired();
            modelBuilder.Entity<SuperPoderesModel>().Property(p => p.SuperPoder).HasMaxLength(50);
            modelBuilder.Entity<SuperPoderesModel>().Property(p => p.Descricao).HasMaxLength(250);

            //modelBuilder.Entity<HeroisSuperpoderesModel>().HasNoKey();

            modelBuilder.Entity<HeroisSuperpoderesModel>().Property(p => p.SuperpoderId).IsRequired();
            modelBuilder.Entity<HeroisSuperpoderesModel>().Property(p => p.HeroiId).IsRequired();
        }


    }
}
