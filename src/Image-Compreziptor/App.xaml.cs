using System.Windows;
using DevExpress.Xpf.Core;

namespace ImageCompreziptor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
   {

        //SplashScreen splashScreen = new SplashScreen(Compreziptor.Properties.Resources.Compressor1.ToString());
        //splashScreen.Show(true);

        // https://stackoverflow.com/questions/25371737/what-is-the-entry-point-of-a-wpf-application
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // here you take control
            //DXSplashScreen.Show<Views.SplashScreenView1>();
        }

    }
}
