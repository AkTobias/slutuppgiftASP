using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StatusRepository :BaseRepository<StatusEntity>
    {
        public StatusRepository(ApplicationDbContext context) : base(context) { }

        public async Task<StatusEntity?> GetByIdAsync(int statusId)
        {
            return await _context.Statuses
                              .FirstOrDefaultAsync(status => status.Id == statusId);
        }
    }
}
