using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tools.Factories
{
    public static class ContextFactory<TDbContext> where TDbContext : DbContext ,new()
    {
        public static TDbContext GetSqlContext(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<TDbContext>();
            builder.UseSqlServer(connectionString);
            return new TDbContext(builder.Options);
        }
    }
}
