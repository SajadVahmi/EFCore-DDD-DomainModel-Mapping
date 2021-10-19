using Microsoft.EntityFrameworkCore;

namespace UseValueObjectAsIdentifier.Persistence.DbContexts
{
    public static class UniversityDbContextFactory
    {
        public static UniversityDbContext GetSqlContext()
        {
            string connectionString = "Server=.;Database=University;Integrated Security=true";
            var builder = new DbContextOptionsBuilder<UniversityDbContext>();
            builder.UseSqlServer(connectionString);

            return new UniversityDbContext(builder.Options);
        }
    }
}
