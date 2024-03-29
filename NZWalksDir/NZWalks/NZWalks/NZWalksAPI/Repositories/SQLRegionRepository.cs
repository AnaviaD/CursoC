using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;
        public SQLRegionRepository(NZWalksDbContext context)
        {
            _context = context;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }
    }
}
