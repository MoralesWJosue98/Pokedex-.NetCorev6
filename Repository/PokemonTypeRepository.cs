using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Repository
{
    public class PokemonTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PokemonTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add Pokemon Type
        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.Set<Pokemon>().AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        // Update Pokemon Type
        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Delete Pokemon Type
        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        // Get all Pokemons Type
        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContext
                .Set<Pokemon>()
                .ToListAsync();
        }

        // Get Pokemon Type by ID
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext
                .Set<Pokemon>()
                .FindAsync(id);
        }

    }
}
