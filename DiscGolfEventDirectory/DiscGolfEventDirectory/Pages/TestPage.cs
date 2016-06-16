using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DiscGolfEventDirectory.Pages
{
	public class TestPage : ContentPage
	{
		public TestPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
