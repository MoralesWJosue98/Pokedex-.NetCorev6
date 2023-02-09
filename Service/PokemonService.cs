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
            Pokemon pokemon = new()
            {
                Id = savePokemon.Id,
                Name = savePokemon.Name,
                Description = savePokemon.Description,
                ImgUrl = savePokemon.ImgUrl,
                PrimaryType = savePokemon.PrimaryType,
                SecondaryType = savePokemon.SecondaryType,
                RegionID = savePokemon.RegionID
            };

            await _repository.AddAsync(pokemon);
        }

        public async Task updateService(SavePokemonViewModel savePokemon)
        {
            Pokemon pokemon = new()
            {
                Id = savePokemon.Id,
                Name = savePokemon.Name,
                Description = savePokemon.Description,
                ImgUrl = savePokemon.ImgUrl,
                PrimaryType = savePokemon.PrimaryType,
                SecondaryType = savePokemon.SecondaryType,
                RegionID = savePokemon.RegionID
            };

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
            SavePokemonViewModel savePokemon = new()
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Description = pokemon.Description,
                ImgUrl = pokemon.ImgUrl,
                PrimaryType = pokemon.PrimaryType,
                SecondaryType = pokemon.SecondaryType,
                RegionID = pokemon.RegionID
            };

            return savePokemon;
        }

        public async Task<List<SavePokemonViewModel>> getAllService()
        {
            var pokemonList = await _repository.GetAllAsync();
            return pokemonList.Select(s => new SavePokemonViewModel
            {
                Name = s.Name,
                Description = s.Description,
                Id = s.Id,
                PrimaryType = s.PrimaryType,
                SecondaryType = s.SecondaryType,
                RegionID = s.RegionID,
                ImgUrl = s.ImgUrl

            }).ToList();
        }
    }
}
