using Pokedex.Models;
using Pokedex.Models.ViewModels;
using Pokedex.Repository;
using Type = Pokedex.Models.Type;

namespace Pokedex.Service
{
    public class TypeService
    {
        private readonly PokemonTypeRepository _repository;

        public TypeService(ApplicationDbContext dbContext)
        {
            _repository = new(dbContext);
        }

        public async Task AddTypeService(SaveTypeViewModel savePk)
        {
            Type pkType = new()
            {
                Id = savePk.Id,
                Name = savePk.Name
            };

            await _repository.AddAsync(pkType);
        }

        public async Task updateTypeService(SaveTypeViewModel saveType)
        {
            Type pkType = new()
            {
                Id = saveType.Id,
                Name = saveType.Name
            };

            await _repository.UpdateAsync(pkType);
        }

        public async Task deleteTypeService(int id)
        {
            var pkType = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(pkType);
        }
        
        public async Task<SaveTypeViewModel> getTypeyIdService(int id)
        {
            var pkType = await _repository.GetByIdAsync(id);
            SaveTypeViewModel savePk = new()
            {
                Id = pkType.Id,
                Name = pkType.Name
            };
            return savePk;
        }

        public async Task<List<SaveTypeViewModel>> getAllTypeService()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new SaveTypeViewModel
            {
                Name = s.Name,
                Id = s.Id

            }).ToList();
        }

    }
}
