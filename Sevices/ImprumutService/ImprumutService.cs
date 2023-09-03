using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ImprumutService : IImprumutService
    {
        private readonly DBCTX _context;

        public ImprumutService(DBCTX context)
        {
            _context = context;
        }

        public List<Imprumut> GetAll()
        {
            return _context.Imprumuturi.ToList();
        }

        public Imprumut Get(int id)
        {
            return _context.Imprumuturi.FirstOrDefault(i => i.Id == id);
        }

        public Imprumut Create(Imprumut imprumut)
        {
            _context.Imprumuturi.Add(imprumut);
            _context.SaveChanges();

            return imprumut;
        }

        public void Update(int id, Imprumut imprumutIn)
        {
            var imprumut = _context.Imprumuturi.FirstOrDefault(i => i.Id == id);
            if (imprumut != null)
            {
                imprumut.UtilizatorId = imprumutIn.UtilizatorId;
                imprumut.CarteId = imprumutIn.CarteId;
                imprumut.DataImprumut = imprumutIn.DataImprumut;
                imprumut.DataReturnare = imprumutIn.DataReturnare;
                
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var imprumut = _context.Imprumuturi.FirstOrDefault(i => i.Id == id);
            if (imprumut != null)
            {
                _context.Imprumuturi.Remove(imprumut);
                _context.SaveChanges();
            }
        }
    }
}