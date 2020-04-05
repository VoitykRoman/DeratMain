using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System;

namespace DeratMain.Services
{
    public class PerimeterService : IPerimeterService
    {
        private readonly IPerimeterRepository _PerimeterRepository;

        public PerimeterService(IPerimeterRepository PerimeterRepository)
        {
            _PerimeterRepository = PerimeterRepository;
        }
        public async Task AddPerimeterAsync(PerimeterCreateModel  PerimeterCreateModel, string name)
        {
            var Perimeter = new Perimeter(PerimeterCreateModel, name);
            await _PerimeterRepository.AddPerimeterAsync(Perimeter, PerimeterCreateModel);
        }

        public async Task<IEnumerable<Perimeter>> GetAllPerimetersAsync()
        {
           var perimeters = await _PerimeterRepository.GetAllPerimetersAsync();
            foreach (var perimeter in perimeters)
            {
                foreach (var trap in perimeter.Traps)
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
            }
            await _PerimeterRepository.SaveChanges();
            return perimeters;
            
        }

        public async Task<Perimeter> GetPerimeterById(int id)
        {
            var perimeter =  await _PerimeterRepository.GetPerimeterById(id);
            foreach (var trap in perimeter.Traps)
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
            await _PerimeterRepository.SaveChanges();
            return perimeter;
        }

        public async Task MarkAsReviewed(int id)
        {
            await _PerimeterRepository.MarkAsReviewed(id);
        }

        public async Task DeletePerimeter(int id)
        {
            await _PerimeterRepository.DeletePerimeter(id);
        }
    }
}
