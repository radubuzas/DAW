using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class ImprumutService : IImprumutService
    {
        private readonly DBCTX _context;
        private readonly IImprumutRepository _repository;

        public ImprumutService(DBCTX context, IImprumutRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<List<Imprumut>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Imprumut> AddAsync(Imprumut imprumut)
        {
            Imprumut newImprumut = new Imprumut
            {
                Id = imprumut.Id,
                UtilizatorId = imprumut.UtilizatorId,
                DataImprumut = imprumut.DataImprumut,
                DataReturnare = imprumut.DataReturnare
            };
            var ret = await _repository.AddAsync(newImprumut);
            await SaveAsync();
            return ret;
        }

        public async Task<bool> UpdateAsync(int IdImprumut, Imprumut imprumut)
        {
            var ret = await _repository.UpdateAsync(IdImprumut, imprumut);
            await SaveAsync();
            return ret;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ret =  await _repository.DeleteAsync(id);
            await SaveAsync();
            return ret;
        }

        public async Task<bool> SaveAsync()
        {
            return await _repository.SaveAsync();
        }

        public async Task<List<Imprumut>> GetActiveRents()
        {
            return await _repository.GetActiveRents();
        }

        public async Task<List<Imprumut>> GetPastRent()
        {
            return await _repository.GetPastRent();
        }

        public async Task<Imprumut> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public int GetNumberOfActiveRents()
        {
            return _repository.GetNumberOfActiveRents();
        }
    }
}