using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.Data;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {

        Task<List<Region>> GetAllAsncy();
        Task<Region> GetByIdAsync(Guid id);

        Task<Region> CreatedAsync(Region region);

        Task<Region> UpdateAsync(Guid id, [FromBody] Region domainRegion);

        Task<Region> DeleteAsync(Guid id);




    }
}
