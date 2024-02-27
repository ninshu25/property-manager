using DataAccess.Context;
using Interfaces.System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Enums;
using Models.System;
using System.Runtime.CompilerServices;

namespace DataAccess.Access
{
    public class DataAccessService : IDataAccessService
    {
        private readonly CRMContext _dbContext;
        private readonly IFactoryService _factoryService;
        private readonly ISessionService _sessionService;

        public DataAccessService(CRMContext dbContext, IFactoryService factoryService, ISessionService sessionService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _factoryService = factoryService ?? throw new ArgumentNullException(nameof(factoryService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
        }

        internal ILoggingService InitializeLogger()
        {
            if (_factoryService == null)
            {
                throw new ArgumentNullException(nameof(_factoryService));
            }

            return _factoryService.CreateLoggingService();
        }

        public IQueryable<TEntity> Query<TEntity>([CallerMemberName] string methodName = "") where TEntity : class
        {
            try
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    IQueryable<TEntity> entities = _dbContext.Set<TEntity>();
                    _loggingService.LogUsageLog(methodName);
                    return entities;
                }
            }
            catch (Exception ex)
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    _loggingService.LogError(ex, "There was an error while querying entities");
                    throw new Exception("There was an error while adding entity: " + ex);
                }
            }
        }

        public void Add<TEntity>(TEntity newEntity) where TEntity : class
        {
            try
            {
                var machineInfoProperty = typeof(TEntity).GetProperty("MachineInfo");
                var idProperty = typeof(TEntity).GetProperty("Id");

                if (machineInfoProperty != null && machineInfoProperty.CanWrite)
                {
                    // Assuming _sessionService is an instance of your session service class
                    machineInfoProperty.SetValue(newEntity, _sessionService.MachineInfo);
                }
                _dbContext.Set<TEntity>().Add(newEntity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    LogMessage logMessage = new LogMessage
                    {
                        Exception = ex,
                        LogType = LogType.Error
                    };

                    _loggingService.Log(logMessage);
                    throw new Exception("There was an error while adding entity: " + ex);
                }
            }
        }

        public void Update<TEntity>(TEntity updatedEntity) where TEntity : class
        {
            try
            {
                _dbContext.Set<TEntity>().Update(updatedEntity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    LogMessage logMessage = new LogMessage
                    {
                        Exception = ex,
                        LogType = LogType.Error
                    };

                    _loggingService.Log(logMessage);
                    throw new Exception("There was an error while updating the entity: " + ex);
                }
            }
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                if (!_dbContext.Set<TEntity>().Local.Contains(entity))
                {
                    _dbContext.Set<TEntity>().Attach(entity);
                }

                _dbContext.Set<TEntity>().Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    LogMessage logMessage = new LogMessage
                    {
                        Exception = ex,
                        LogType = LogType.Error
                    };

                    _loggingService.Log(logMessage);
                    throw new Exception("There was an error while removing the entity: " + ex);
                }
            }
        }

        public void RemoveRange<TEntity>(TEntity entity) where TEntity : class 
        {
            try
            {
                _dbContext.Set<TEntity>().RemoveRange(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    LogMessage logMessage = new LogMessage
                    {
                        Exception = ex,
                        LogType = LogType.Error
                    };

                    _loggingService.Log(logMessage);
                    throw new Exception("There was an error while removing the entity: " + ex);
                }
            }
        }

        public async void RemoveById<TEntity>(object id) where TEntity : class
        {
            try
            {
                var entity = await _dbContext.Set<TEntity>().FindAsync(id);
                if (entity != null)
                {
                    Remove(entity);
                }
            }
            catch (Exception ex)
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    LogMessage logMessage = new LogMessage
                    {
                        Exception = ex,
                        LogType = LogType.Error
                    };

                    _loggingService.Log(logMessage);
                    throw new Exception("There was an error while removing the entity: " + ex);
                }
            }
        }

        public async void SoftRemoveById<TEntity>(object id) where TEntity : class
        {
            try
            {
                var tableName = _dbContext.Model.FindEntityType(typeof(TEntity)).GetTableName();
                var schemaName = _dbContext.Model.FindEntityType(typeof(TEntity)).GetSchema();
                var updateSql = $"UPDATE [{schemaName}].[{tableName}] SET Deleted = 1 WHERE Id = @id";

                _dbContext.Database.ExecuteSqlRawAsync(updateSql, new SqlParameter("@id", id));

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                using (ILoggingService _loggingService = InitializeLogger())
                {
                    _loggingService.LogError(ex, "There was an error while soft removing the entity");
                }
            }
        }
    }

}
