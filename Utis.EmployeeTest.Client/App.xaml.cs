using System;
using System.Windows;
using Utis.EmployeeTest.Client.Views;
using Prism.Ioc;
using Prism.Unity;
using Utis.EmployeeTest.Client.Services;
using Utis.EmployeeTest.Client.ViewModels;

namespace Utis.EmployeeTest.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainShell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataService, DataService>();
            containerRegistry.RegisterDialog<WorkerEditor, WorkerEditorViewModel>();
        }
    }
}
