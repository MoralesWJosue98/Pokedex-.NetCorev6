using Pokedex.Models;
using Pokedex.Models.ViewModels;
using Pokedex.Repository;

namespace Pokedex.Service
{
    public class PokemonService
    {
        private readonly PokemonRepository _repository;

        public PokemonService(ApplicationDbContext dbContext)
        {
            _repository = new(dbContext);
        }
        public async Task addService(SavePokemonViewModel savePokemon)
        {
            Pokemon pokemon = new();
            pokemon.Id = savePokemon.Id;
            pokemon.Name = savePokemon.Name;
            pokemon.Description = savePokemon.Description;
            pokemon.ImgUrl = savePokemon.ImgUrl;
            pokemon.PrimaryType = savePokemon.PrimaryType;
            pokemon.SecondaryType = savePokemon.SecondaryType;
            pokemon.RegionID = savePokemon.RegionID;

            await _repository.AddAsync(pokemon);
        }

        public async Task updateService(SavePokemonViewModel savePokemon)
        {
            Pokemon pokemon = new();
            pokemon.Id = savePokemon.Id;
            pokemon.Name = savePokemon.Name;
            pokemon.Description = savePokemon.Description;
            pokemon.ImgUrl = savePokemon.ImgUrl;
            pokemon.PrimaryType = savePokemon.PrimaryType;
            pokemon.SecondaryType = savePokemon.SecondaryType;
            pokemon.RegionID = savePokemon.RegionID;

            await _repository.UpdateAsync(pokemon);
        }

        public async Task deleteService(int id)
        {
            var pokemon = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> getPokemonByIdService(int id)
        {
            var pokemon = await _repository.GetByIdAsync(id);
            SavePokemonViewModel savePokemon = new();
            savePokemon.Id = pokemon.Id;
            savePokemon.Name = pokemon.Name;
            savePokemon.Description = pokemon.Description;
            savePokemon.ImgUrl = pokemon.ImgUrl;
            savePokemon.PrimaryType = pokemon.PrimaryType;
            savePokemon.SecondaryType = pokemon.SecondaryType;
            savePokemon.RegionID = pokemon.RegionID;

            return vm;
        }
    }
}
