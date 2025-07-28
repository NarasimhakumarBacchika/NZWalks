using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DTO;
using NZWalks.API.Model.Data;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDb;
        //value can be assigned only once, either during its declaration or within a constructor of the same class.
        public SQLRegionRepository(NZWalksDbContext nZWalksDb)
        {
            this.nZWalksDb = nZWalksDb;
        }

        public async Task<Region> CreatedAsync(Region region)
        {
            await  nZWalksDb.Regions.AddAsync(region);
            await  nZWalksDb.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var RegionDoimn=await nZWalksDb.Regions.FirstOrDefaultAsync(x=>x.Id==id);

            if (RegionDoimn==null)
            {
                return null;
            }
            nZWalksDb.Remove(RegionDoimn);
            await nZWalksDb.SaveChangesAsync();
            return RegionDoimn;


        }

        public async  Task<List<Region>> GetAllAsncy()
        {
            return await nZWalksDb.Regions.ToListAsync();
        }

        public async Task<Region> GetByIdAsync(Guid id)
        {
            return  await nZWalksDb.Regions.FirstOrDefaultAsync(x => x.Id == id); 

        }

        public async Task<Region> UpdateAsync(Guid id, [FromBody] Region domainRegion)
        {
            var existingRegion= await nZWalksDb.Regions.FirstOrDefaultAsync(x=>x.Id == id);

            if(existingRegion==null)
            {
                return null;
            }

            existingRegion.Code=domainRegion.Code;
            existingRegion.Name=domainRegion.Name;
            existingRegion.RegionImageUrl=domainRegion.RegionImageUrl;

            await nZWalksDb.SaveChangesAsync();

            return existingRegion;
        }
    }
}
