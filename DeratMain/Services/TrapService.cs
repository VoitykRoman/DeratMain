using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System;

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

        public async Task DeleteTrap(int id)
        {
            await _TrapRepository.DeleteTrap(id);
        }

        public async Task<IEnumerable<Trap>> GetAllTrapsAsync()
        {
            var traps = await _TrapRepository.GetAllTrapsAsync();

            foreach (var trap in traps)
            {
                if (trap.NextReviewTime > trap.EndTime)
                {
                    trap.NextReviewTime = trap.EndTime;
                }
                if (trap.NextReviewTime > DateTime.Now)
                {
                    trap.Status = "ok";
                }
                else
                {
                    trap.Status = "overdue";
                }

               
            }
            await _TrapRepository.UpdateTrapsAsync();
            return traps;
        }

        public async Task<Trap> GetTrapById(int id)
        {
           return await _TrapRepository.GetTrapById(id);
        }

        public async Task MarkAsReviewed(int id)
        {
            await _TrapRepository.MarkAsReviewed(id);
        }
    }
}
