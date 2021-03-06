﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DiscGolfEventDirectory
{
	public class App : Application
	{
		public App ()
		{
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("11CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6EA22E"));

            NavigationPage nav = new NavigationPage(new LoginPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
