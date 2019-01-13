using Lamar;
using Microsoft.Extensions.Configuration;
using ShatteredLibrary.Options;
using System.Windows;

namespace ShatteredLibrary.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create our dependency injection container from all
            // ShatteredLibrary ServiceRegistries in our bin directory.
            var registry = new ServiceRegistry();
            registry.Scan(scan =>
            {
                scan.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.FullName.Contains("ShatteredLibrary"));
                scan.LookForRegistries();
            });
            RegisterOptions(registry);
            var container = new Container(registry);
            container.AssertConfigurationIsValid();

            // Resolve and show the window.
            var window = container.GetInstance<MainWindow>();
            window.Show();
        }

        private void RegisterOptions(ServiceRegistry registry)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: true)
                .Build();

            var databaseSettingsSection = configuration.GetSection("DatabaseSettings");
            var databaseSettings = databaseSettingsSection.Get<DatabaseSettings>();
            registry.For<DatabaseSettings>().Use(databaseSettings).Singleton();
        }
    }
}
