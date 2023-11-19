using Prism.Ioc;
using Prism.Unity;
using System.Windows;


namespace Sandbox
{
    public partial class App : PrismApplication
    {
        #region  ---   Overrides   ---

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Registering services

        }

        #endregion
    }
}
