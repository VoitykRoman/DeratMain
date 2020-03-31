﻿using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface ITrapRepository
    {
        Task<IEnumerable<Trap>> GetAllTrapsAsync();

        Task AddTrapAsync(Trap Trap, TrapCreateModel TrapCreateModel);
    }
}