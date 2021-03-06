﻿using DependencyViewModel;
using KinectSandbox.Capture;
using KinectSandbox.ColorPicker;
using KinectSandbox.Shell;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KinectSandbox
{
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the shell, or "Main Window" of the application
        /// </summary>        
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellWindow>() as DependencyObject;            
        }

        /// <summary>
        /// Initializes the shell
        /// </summary>
        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        { 
            base.ConfigureContainer();

            Container.AddNewExtension<Interception>();

            Container.RegisterType<ShellWindow>();
            Container.RegisterType<IShellViewModel, ShellViewModel>();

            Container.RegisterType<IPropertyStore, DictionaryPropertyStore>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var mc = new ModuleCatalog();            
            mc.AddModule(typeof(CaptureModule));
            mc.AddModule(typeof(ColorPickerModule));

            return mc;
        }
    }
}
