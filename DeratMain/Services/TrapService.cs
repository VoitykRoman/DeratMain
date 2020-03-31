using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;

namespace DeratMain.Services
{
    public class TrapService : ITrapService
    {
        private readonly ITrapRepository _TrapRepository;

        public TrapService(ITrapRepository TrapRepository)
        {
            _TrapRepository = TrapRepository;
        }
        public async Task AddTrapAsync(TrapCreateModel  TrapCreateModel, string name)
        {
            var Trap = new Trap(TrapCreateModel, name);
            await _TrapRepository.AddTrapAsync(Trap, TrapCreateModel);
        }

        public async Task<IEnumerable<Trap>> GetAllTrapsAsync()
        {
            return await _TrapRepository.GetAllTrapsAsync();
        }

    }
}
