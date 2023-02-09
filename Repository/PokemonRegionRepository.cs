using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Repository
{
    public class PokemonRegionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PokemonRegionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add Pokemon Region
        public async Task AddAsync(Region pokemonRegion)
        {
            await _dbContext.Set<Region>().AddAsync(pokemonRegion);
            await _dbContext.SaveChangesAsync();
        }

        // Update Pokemon Region
        public async Task UpdateAsync(Region pokemonRegion)
        {
            _dbContext.Entry(pokemonRegion).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Delete Pokemon Region
        public async Task DeleteAsync(Region pokemonRegion)
        {
            _dbContext.Set<Region>().Remove(pokemonRegion);
            await _dbContext.SaveChangesAsync();
        }

        // Get all Pokemons Regions
        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext
                .Set<Region>()
                .ToListAsync();
        }

        // Get Pokemon Region by ID
        public async Task<Region> GetByIdAsync(int id)
        {
            return await _dbContext
                .Set<Region>()
                .FindAsync(id);
        }
    }
}
