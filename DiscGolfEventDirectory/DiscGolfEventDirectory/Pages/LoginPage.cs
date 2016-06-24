using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DiscGolfEventDirectory { 

	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            Button loginButton = new Button()
            {
                Text = "Login, Loser",
                HorizontalOptions = LayoutOptions.Center
            };
            loginButton.Clicked += (sender, e) => {
                var eventListPage = new EventListPage();
                Navigation.PushAsync(eventListPage);
                Navigation.RemovePage(this);

            };
            Label userLabel = new Label()
            {
                Text = "Username:",
                HorizontalOptions = LayoutOptions.Center
            };

            Label passLabel = new Label()
            {
                Text = "Password:",
                HorizontalOptions = LayoutOptions.Center
            };
            Entry userEntry = new Entry()
            {
                HorizontalOptions = LayoutOptions.Center,
                Placeholder = "Enter Username"
            };
            Entry passEntry = new Entry()
            {
                HorizontalOptions = LayoutOptions.Center,
                Placeholder = "Enter Password",
                IsPassword = true
            };
            Content = new StackLayout {
                Children = {
                     userLabel,
                     userEntry,
                     passLabel,
                     passEntry,
                     loginButton
                }
            };
		}
	}
}
