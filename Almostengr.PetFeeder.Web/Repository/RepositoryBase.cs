using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Data;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Repository
{
    public abstract class RepositoryBase<Entity> : IRepositoryBase<Entity> where Entity : ModelBase
    {
        private readonly PetFeederDbContext _dbContext;
        private readonly ILogger<RepositoryBase<Entity>> _logger;
        private DbSet<Entity> _table = null;

        public RepositoryBase(PetFeederDbContext dbContext, ILogger<RepositoryBase<Entity>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _table = _dbContext.Set<Entity>();
        }

        public void Delete(Entity entity)
        {
            _table.Remove(entity);
            _logger.LogInformation($"Entity {nameof(Entity)} deleted");
        }

        public async Task<IList<Entity>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task AddAsync(Entity entity)
        {
            await _table.AddAsync(entity);
            _logger.LogInformation($"Entity {nameof(Entity)} created");
        }

        public void Update(Entity entity)
        {
            _table.Update(entity);
            _logger.LogInformation($"Entity {nameof(Entity)} updated");
        }

        public void UpdateRange(IList<Entity> entities)
        {
            _table.UpdateRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("Saved changes to database.");
        }

    }
}