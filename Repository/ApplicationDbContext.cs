using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using Type = Pokedex.Models.Type;

namespace Pokedex.Repository
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region> pokemonRegion { get; set; }    
        public DbSet<Type> pokemonType { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nomenclatura Fluent API configuración de entidades
            #region tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<Region>().ToTable("pokemonRegion");
            modelBuilder.Entity<Type>().ToTable("pokemonType");
            #endregion

            #region "Primary keys"
            modelBuilder.Entity<Pokemon>().HasKey(p => p.Id); //lambda
            modelBuilder.Entity<Region>().HasKey(r => r.Id);
            modelBuilder.Entity<Type>().HasKey(t => t.Id);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(r => r.Pokemons)
                .WithOne(p => p.pokemonRegion).HasForeignKey(p => p.RegionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Type>()
                .HasMany<Pokemon>(r => r.Pokemons)
                .WithOne(p => p.pokemonType).HasForeignKey(p => p.PrimaryType).HasForeignKey(p => p.SecondaryType)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"
            #region Pokemon
            modelBuilder.Entity<Pokemon>().Property(p => p.Id).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Pokemon>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Pokemon>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Pokemon>().Property(p => p.ImgUrl).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Pokemon>().Property(p => p.PrimaryType).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(p => p.SecondaryType).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(p => p.RegionID).IsRequired();
            #endregion
            #region Region
            modelBuilder.Entity<Region>().Property(r => r.Id).IsRequired();
            modelBuilder.Entity<Region>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Region>().Property(r => r.Description).IsRequired();

            #endregion
            #region Type
            modelBuilder.Entity<Type>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Type>().Property(t => t.Id).IsRequired();
            #endregion
            #endregion



        }



    }
}
