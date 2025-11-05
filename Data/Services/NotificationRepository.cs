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
    public class NotificationRepository : DataGeneric<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .Include(e => e.UserPlant)
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }
    }
}
