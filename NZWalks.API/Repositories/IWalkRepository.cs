using NZWalks.API.Model.Data;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk>CreateAsync(Walk walk);
        Task<Walk>GetByIdAsync(Guid id);

       Task<List<Walk>> GetAllAsync();

        Task<Walk> UpdateAsync(Guid id, Walk walk);

        Task<Walk> DeleteAsync(Guid id);

    }
}
