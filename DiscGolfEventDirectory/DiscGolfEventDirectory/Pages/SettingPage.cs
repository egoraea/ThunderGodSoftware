using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Plugin.Settings;

namespace DiscGolfEventDirectory
{
	public class SettingPage : ContentPage
	{
		public SettingPage ()
		{
            Title = "Settings";


			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
