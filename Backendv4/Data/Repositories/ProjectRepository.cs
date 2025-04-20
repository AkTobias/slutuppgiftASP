using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProjectRepository : BaseRepository<ProjectEntity>
    {

        public ProjectRepository(ApplicationDbContext context) : base(context) { }

        private IQueryable<ProjectEntity> IncludeRelatedEntities (IQueryable<ProjectEntity> query)
        {
            return query
                .Include(x => x.Client)
                .Include(x => x.Owner)
                .Include(x => x.Status);
        }

        public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            var entites = await IncludeRelatedEntities(_table).ToListAsync();
            return entites;
        }
   
        public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
        {
            var entity = await _table
              .Include(x => x.Client)
              .Include(x => x.Owner)
              .Include(x => x.Status)
              .FirstOrDefaultAsync(expression);

            return entity;
        }
    }
}
