using System.Runtime.CompilerServices;

namespace Interfaces.System
{
    public interface IDataAccessService
    {
        IQueryable<TEntity> Query<TEntity>([CallerMemberName] string methodName = "") where TEntity : class;
        void Add<TEntity>(TEntity newEntity) where TEntity : class;
        void Update<TEntity>(TEntity updatedEntity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(TEntity entity) where TEntity : class;
        void RemoveById<TEntity>(object id) where TEntity : class;
        void SoftRemoveById<TEntity>(object id) where TEntity : class;
    }

}
