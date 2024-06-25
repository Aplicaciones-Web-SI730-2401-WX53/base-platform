using BasePlatform.API.Operation.Domain.Models.Comands;

namespace BasePlatform.API.Operation.Domain.Services.Comands;

public interface IGuardianCommandService
{
    Task<int> HandleAsync(CreateGuardianCommand command);
}