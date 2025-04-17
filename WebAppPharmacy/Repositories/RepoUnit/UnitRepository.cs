using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoUnit
{
    public class UnitRepository : IUnitRepository
    {
        private readonly WebAppPharmacyContext _context;
        private readonly IMapper _mapper;

        public UnitRepository(WebAppPharmacyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _context.Units.ToListAsync();
        }

        public async Task<Unit> GetByIdAsync(long id)
        {
            return await _context.Units.FindAsync(id);
        }

        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Unit unit)
        {
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit != null)
            {
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string unitName, long? excludeId = null)
        {
            return await _context.Units.AnyAsync(u =>
                u.Name == unitName &&
                (!excludeId.HasValue || u.Id != excludeId.Value));
        }

    }
}
