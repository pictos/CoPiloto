﻿using CoPiloto.Services.Navigation;
using CoPiloto.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CoPiloto
{
    public partial class App : Application
    {
        public App()
        {
            LiveReload.Init();
            InitializeComponent();
            //MainPage = new Views.MDPage();
            NavigationService.Current.SetarMainPage<SplashViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
