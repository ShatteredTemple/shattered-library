using Lamar;

namespace ShatteredLibrary.DAL
{
    public class DataAccessRegistry : ServiceRegistry
    {
        public DataAccessRegistry()
        {
            // Sqlite-specific DAL.
            For<LibraryContext>().Use<SqlLiteLibraryContext>();

            // Register configuration options we depend on as singletons.
            //            For<DatabaseSettings>().Use(ctx => ctx.GetInstance<IOptions<DatabaseSettings>>().Value).Singleton();
        }
    }
}
