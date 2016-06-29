using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DiscGolfEventDirectory.Pages
{
	public class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
