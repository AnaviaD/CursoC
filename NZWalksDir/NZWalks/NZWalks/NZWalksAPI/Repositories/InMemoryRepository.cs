using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class InMemoryRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "SAM",
                    Name = "Name",
                    RegionImageUrl = "random-Url.jpg"
                }
            };
        }
    }
}
