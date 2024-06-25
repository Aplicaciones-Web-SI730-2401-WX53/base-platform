using BasePlatform.API.Operation.Domain.Models.Entities;
using BasePlatform.API.Operation.Domain.Repositories;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasePlatform.API.Operation.Infrastructure.Repositories;

public class GuardianRepository : BaseRepository<Guardian>, IGuardianRepository
{
    
    public GuardianRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<List<Guardian>> GetGuardiansByusername(string Username)
    {
        return await Context.Set<Guardian>().Where(g => g.Username == Username).ToListAsync();
    }
}