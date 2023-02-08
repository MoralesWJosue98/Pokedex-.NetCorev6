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
        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.Set<Pokemon>().AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        // Update Pokemon Region
        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Delete Pokemon Region
        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        // Get all Pokemons Regions
        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContext
                .Set<Pokemon>()
                .ToListAsync();
        }

        // Get Pokemon Region by ID
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext
                .Set<Pokemon>()
                .FindAsync(id);
        }
    }
}
