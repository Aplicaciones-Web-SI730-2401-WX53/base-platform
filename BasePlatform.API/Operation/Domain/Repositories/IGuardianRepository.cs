using BasePlatform.API.Operation.Domain.Models.Entities;
using BasePlatform.API.Shared.Domain.Repositories;

namespace BasePlatform.API.Operation.Domain.Repositories;

public interface IGuardianRepository : IBaseRepository<Guardian>
{
    Task<List<Guardian>> GetGuardiansByusername(string Username);
}