using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Data;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository:IWalkRepository
    {

        private readonly NZWalksDbContext nZWalksDb;

        public SQLWalkRepository(NZWalksDbContext nZWalksDb)
        {
            this.nZWalksDb = nZWalksDb;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await nZWalksDb.Walks.AddAsync(walk);
            await nZWalksDb.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await nZWalksDb.Walks.Include("Diffculty").Include("Region").ToListAsync();
        }



        public async Task<Walk> GetByIdAsync(Guid id)
        {
            var WalkDomin = await nZWalksDb.Walks.FirstOrDefaultAsync(x => x.Id == id);

            return WalkDomin;

        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var  WalkDomain= await nZWalksDb.Walks.FirstOrDefaultAsync(x=>x.Id == id);
            if (WalkDomain == null)
            {
                return null;
            }

            WalkDomain.Name = walk.Name;
            WalkDomain.Description= walk.Description;
            WalkDomain.LengthInKm= walk.LengthInKm;
            WalkDomain.WalkImageUrl= walk.WalkImageUrl;
            WalkDomain.DiffcultyId= walk.DiffcultyId;
            WalkDomain.RegionId= walk.RegionId;

            await nZWalksDb.SaveChangesAsync();

            return WalkDomain;
        }
        public async Task<Walk> DeleteAsync(Guid id)
        {
            var WalkDomain=await nZWalksDb.Walks.FirstOrDefaultAsync(x=>x.Id==id);
            if (WalkDomain == null)
            {
                return null;
            }
             nZWalksDb.Remove(WalkDomain);
            await   nZWalksDb.SaveChangesAsync();

            return WalkDomain;
        }

        
    }
}
