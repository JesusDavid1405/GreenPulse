using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Infrastructure.Context;
using Entity.Models.Implements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class PlantSpeciesRepository : DataGeneric<PlantSpecies>, IPlantSpeciesRepository
    {
        public PlantSpeciesRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<PlantSpecies>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .Include(e => e.PlantCategory)  
                .Where(e => !e.IsDeleted)
                .OrderBy(e => e.CreatedAt)
                .ToListAsync();
        }

    }
}
