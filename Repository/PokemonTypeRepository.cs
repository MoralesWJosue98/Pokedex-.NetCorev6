using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using Type = Pokedex.Models.Type;

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
        public async Task AddAsync(Type pokemonType)
        {
            await _dbContext.Set<Type>().AddAsync(pokemonType);
            await _dbContext.SaveChangesAsync();
        }

        // Update Pokemon Type
        public async Task UpdateAsync(Type pokemonType)
        {
            _dbContext.Entry(pokemonType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Delete Pokemon Type
        public async Task DeleteAsync(Type pokemonType)
        {
            _dbContext.Set<Type>().Remove(pokemonType);
            await _dbContext.SaveChangesAsync();
        }

        // Get all Pokemons Type
        public async Task<List<Type>> GetAllAsync()
        {
            return await _dbContext
                .Set<Type>()
                .ToListAsync();
        }

        // Get Pokemon Type by ID
        public async Task<Type> GetByIdAsync(int id)
        {
            return await _dbContext
                .Set<Type>()
                .FindAsync(id);
        }

    }
}
