using App.Core.Services;
using App.WindowsApp.Forms;

namespace App.WindowsApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string connString = "Server=localhost;Database=ITAssetManagerDB;Trusted_Connection=True;TrustServerCertificate=True;";

            Application.Run(new MainForm(connString));
        }
    }
}