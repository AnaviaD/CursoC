using testAppN1.Models.Domain;

namespace testAppN1.Repositories
{
    public class SQLRegionRepository : RegionRepository
    {
        public Task<List<Region>> GetAllRegionAsync(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
