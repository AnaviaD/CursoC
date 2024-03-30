using testAppN1.Models.Domain;

namespace testAppN1.Repositories
{
    public interface RegionRepository
    {
        public Task<List<Region>> GetAllRegionAsync(Region region);
    }
}
