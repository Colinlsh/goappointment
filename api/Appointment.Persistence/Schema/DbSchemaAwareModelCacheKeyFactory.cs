using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Appointment.Persistence.Schema
{
    public class DbSchemaAwareModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            return new
            {
                Type = context.GetType(),
                Schema = context is IDbContextSchema schema ? schema.Schema : null
            };
        }
    }
}
