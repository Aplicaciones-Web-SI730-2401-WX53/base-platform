using System.Data;
using BasePlatform.API.Operation.Domain.Models.Comands;
using BasePlatform.API.Operation.Domain.Models.Entities;
using BasePlatform.API.Operation.Domain.Repositories;
using BasePlatform.API.Operation.Domain.Services.Comands;
using BasePlatform.API.Shared.Domain.Repositories;

namespace BasePlatform.API.Operation.Application.Services.Commands;

public class GuardinaCommandService : IGuardianCommandService
{
    private readonly IGuardianRepository _guardianRepository;
    private readonly IUnitOfWork _unitOfWork; 
    
    public GuardinaCommandService(IGuardianRepository guardianRepository,IUnitOfWork unitOfWork)
    {
        _guardianRepository = guardianRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> HandleAsync(CreateGuardianCommand command)
    {
        var guardian = new Guardian()
        {
            Username = command.Username,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName
        };

      //  var result = await _guardianRepository.ListAsync();  //2M refr  SELCT * from  guardin Where 1 = 1
      //  var guardianExists = result.FirstOrDefault(x => x.Username == command.Username); 
        
      var guardianExists = await _guardianRepository.GetGuardiansByusername(command.Username); //2M SELCT * from  guardin Where usenamr  = @Username
      
      if( guardianExists != null)
            throw new DuplicateNameException("username already exists");
        
        
        await _guardianRepository.AddAsync(guardian);
        await _unitOfWork.CompleteAsync();

        return 0;
    }
}