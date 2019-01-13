using Microsoft.EntityFrameworkCore;
using ShatteredLibrary.Options;

namespace ShatteredLibrary.DAL
{
    public class SqliteLibraryContext : LibraryContext
    {
        private readonly DatabaseSettings m_databaseSettings;

        public SqliteLibraryContext(DatabaseSettings databaseSettings)
        {
            this.m_databaseSettings = databaseSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(this.m_databaseSettings.ConnectionString);
        }
    }
}
