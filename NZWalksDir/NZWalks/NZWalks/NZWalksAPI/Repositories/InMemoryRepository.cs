﻿using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class InMemoryRepository : IRegionRepository
    {
        public Task<Region?> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

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

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
