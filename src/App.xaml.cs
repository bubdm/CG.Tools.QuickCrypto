using Microsoft.Extensions.Configuration;
using System;
using System.Windows;

namespace CG.Tools.QuickCrypto
{
    /// <summary>
    /// This class represents the code-behind for the application.
    /// </summary>
    public partial class App : Application
    {
        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is called when the application starts.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnStartup(
            StartupEventArgs e
            )
        {
            // Build the configuration.
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appSettings.json")
                .AddUserSecrets<App>();
            var configuration = builder.Build();

            // Set the syncfusion license key.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                configuration["Syncfusion"]
                );

            // Create and show the splash screen.
            var splashScreen = new SplashScreen("/Images/Splash.png");
            splashScreen.Show(true);

            // Wire up a handler, just in case ...
            AppDomain.CurrentDomain.UnhandledException += (s, ex) =>
            {
                // Tell the world about our little problem ...
                MessageBox.Show(
                    (ex.ExceptionObject as Exception).Message +
                    Environment.NewLine +
                    (ex.ExceptionObject as Exception).StackTrace
                    );
            };

            // Give the base class a chance.
            base.OnStartup(e);
        }

        #endregion
    }
}