using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Appointment.Persistence.Schema
{
    [SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
    public class DbSchemaAwareMigrationAssembly : MigrationsAssembly
    {
        private readonly DbContext _context;
        public DbSchemaAwareMigrationAssembly([NotNull] ICurrentDbContext currentContext, [NotNull] IDbContextOptions options, [NotNull] IMigrationsIdGenerator idGenerator, [NotNull] IDiagnosticsLogger<DbLoggerCategory.Migrations> logger) : base(currentContext, options, idGenerator: idGenerator, logger: logger)
        {
            _context = currentContext.Context;
        }

        public override Migration CreateMigration(TypeInfo migrationClass, string activeProvider)
        {
            if (activeProvider == null)
                throw new ArgumentNullException(nameof(activeProvider));

            var hasCtorWithSchema = migrationClass
                    .GetConstructor(new[] { typeof(IDbContextSchema) }) != null;

            if (hasCtorWithSchema && _context is IDbContextSchema schema)
            {
                var instance = (Migration)Activator.CreateInstance(migrationClass.AsType(), schema);
                instance.ActiveProvider = activeProvider;
                return instance;
            }

            //Debugger.Launch();

            return base.CreateMigration(migrationClass, activeProvider);
        }
    }
}
