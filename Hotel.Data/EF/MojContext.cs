﻿using Microsoft.EntityFrameworkCore;


namespace Hotel.Data.Models
{
    public class MojContext : DbContext
    {

        public DbSet<CheckIN> CheckIN { set; get; }
        public DbSet<Pogodnost> Pogodnost { set; get; }
        public DbSet<Racun> Racun { set; get; }
        public DbSet<RezervisanSmjestaj> RezervisanSmjestaj { set; get; }
        public DbSet<RezervisanaUsluga> RezervisanaUsluga { set; get; }
        public DbSet<Smjestaj> Smjestaj { set; get; }
        public DbSet<Stavke> Stavke { set; get; }
        public DbSet<TipUsluge> TipUsluge { set; get; }
        public DbSet<UslugeHotela> UslugeHotela { set; get; }
        public DbSet<VrstaSmjestaja> VrstaSmjestaja { set; get; }
        public DbSet<ZahtjevZaCiscenjem> ZahtjevZaCiscenjem { set; get; }
        public DbSet<Zaposlenik> Zaposlenik { set; get; }
        public DbSet<Proizvodi> Proizvod { set; get; }
        public DbSet<PogodnostiSmjestaja> PogodnostiSmjestaja { set; get; }
        public DbSet<Narudzba> Narudzba { set; get; }
        public DbSet<Gost> Gost { set; get; }
        public DbSet<Feedback> Feedback { set; get; }
        public DbSet<Grad> Grad { set; get; }
        public DbSet<Drzava> Drzava { set; get; }
        public DbSet<DostavaStavke> DostavaStavke { set; get; }
        public DbSet<Dostava> Dostava { set; get; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=p1714.app.fit.ba;Database=p1714_Hotel;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=p1714;Password=F7z3t8_n");
            optionsBuilder.UseSqlServer("Server=localhost;Database=Hotel;Trusted_Connection=true;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=Hotel;Trusted_Connection=true;MultipleActiveResultSets=true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RezervisanSmjestaj>().HasOne(a => a.Gost).WithMany().HasForeignKey(a => a.GostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Feedback>().HasOne(a => a.Gost).WithMany().HasForeignKey(a => a.GostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Racun>().HasOne(a => a.Gost).WithMany().HasForeignKey(a => a.GostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CheckIN>().HasOne(a => a.Zaposlenik).WithMany().HasForeignKey(a => a.ZaposlenikId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
