﻿using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace YoChat.Helpers
{
    public static class TheTheme
    {
        private static readonly IThemeService _themeService = SimpleIoc.Default.GetInstance<IThemeService>();
        public static void SetTheme()
        {
            switch (Settings.Theme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }

            var nav = App.Current.MainPage as Xamarin.Forms.NavigationPage;

            var e = DependencyService.Get<IEnvironment>();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                _themeService.IsLightTheme = false;
                e?.SetStatusBarColor(Color.FromHex("212D3B"), false);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.FromHex("212D3B");
                    nav.BarTextColor = Color.White;
                }
            }
            else
            {
                _themeService.IsLightTheme = true;
                e?.SetStatusBarColor(Color.FromHex("517DA2"), true);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.FromHex("517DA2");
                    nav.BarTextColor = Color.Black;
                }
            }
        }
    }
}
