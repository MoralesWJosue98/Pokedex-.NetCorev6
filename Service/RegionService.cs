using Pokedex.Models.ViewModels;
using Pokedex.Models;
using Pokedex.Repository;

namespace Pokedex.Service
{
    public class RegionService
    {
        private readonly PokemonRegionRepository _repository;

        public RegionService(ApplicationDbContext dbContext)
        {
            _repository = new(dbContext);
        }

        public async Task addRegionService(SaveRegionViewModel saveRegion)
        {
            Region pkRegion = new()
            {
                Id = saveRegion.Id,
                Name = saveRegion.Name,
                Description = saveRegion.Description
            };

            await _repository.AddAsync(pkRegion);
        }

        public async Task updateRegionService(SaveRegionViewModel saveRegion)
        {
            Region pkRegion = new()
            {
                Id = saveRegion.Id,
                Name = saveRegion.Name,
                Description = saveRegion.Description
            };

            await _repository.UpdateAsync(pkRegion);
        }

        public async Task deleteRegionService(int id)
        {
            var pkRegion = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(pkRegion);
        }

        public async Task<SaveRegionViewModel> getRegionByIdService(int id)
        {
            var pkRegion = await _repository.GetByIdAsync(id);
            SaveRegionViewModel savePk = new()
            {
                Id = pkRegion.Id,
                Name = pkRegion.Name,
                Description = pkRegion.Description
            };
            return savePk;
        }

        public async Task<List<SaveRegionViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new SaveRegionViewModel
            {
                Name = s.Name,
                Description = s.Description,
                Id = s.Id

            }).ToList();
        }
    }
}
