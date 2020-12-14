﻿using System;
using System.Windows;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.Interfaces;
using OrionManager.Services;
using OrionManager.ViewModel;
using OrionManager.ViewModel.ViewModels.Main;
using OrionManager.Views;
using OrionManager.Views.Backgrounds;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Configuration;
using OrionManager.Views.Regions.Playing;
using Senticode.Wpf.Extensions;
using Unity;

namespace OrionManager
{
    internal partial class App
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            DispatcherUnhandledException += (s, e) => this.LogCriticalException(e.Exception);

            try
            {
                Container.Resolve<IAppLifecycleService>().ExitApp = Shutdown;
                Container.Resolve<IAppLifecycleService>().OnStart();

                this.SetMainWindow<MainWindow, MainViewModel>();

                Container.Resolve<MainWindow>().Show();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            try
            {
                ServicesInitializer.Instance.Init(Container);
                ViewModelInitializer.Instance.Init(Container);

                Container

                    // MainWindow.
                   .RegisterSingleton<MainWindow>()

                    // Regions.
                   .RegisterSingleton<StartRegion>()
                   .RegisterSingleton<ConfigurationRegion>()
                   .RegisterSingleton<PlayingRegion>()
                   .RegisterSingleton<PreStartRegion>()
                   .RegisterSingleton<ConfigurationListRegion>()

                    // Backgrounds.
                   .RegisterSingleton<StartBackground>()
                   .RegisterSingleton<PreStartBackground>()
                   .RegisterSingleton<ConfigurationBackground>()
                   .RegisterSingleton<PlayingBackground>()
                   .RegisterSingleton<ConfigurationListBackground>()

                    //
                    ;
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        protected override void OnExit(ExitEventArgs args)
        {
            base.OnExit(args);

            try
            {
                Container.Resolve<IAppLifecycleService>().OnExit();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }
    }
}