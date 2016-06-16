using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace DiscGolfEventDirectory
{
	public class EventListPage : ContentPage
	{
        ListView listView;
        public EventListPage ()
		{
            Title = "Events";

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new ListView
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof(EventItemCell))
            };

            listView.ItemsSource = new EventItem[] {
                            new EventItem { Name = "Buy pears`",Address = "123 Apple STreet", Date
                             = new DateTime(1993,12,12),Information= "You buy pears with your discs", Type = "Mini"},
                            new EventItem { Name = "Buy not pears`",Address = "123 Apple STreet", Date
                             = new DateTime(1993,12,12),Information= "You buy pears with your discs", Type = "Mini"}
                        };

            listView.ItemSelected += (sender, e) => {
                var eventItem = (EventItem)e.SelectedItem;
                var eventDetailsPage = new EventDetailsPage();
                eventDetailsPage.BindingContext = eventItem;
                Navigation.PushAsync(eventDetailsPage);
            };

            var layout = new StackLayout();

            layout.Children.Add(listView);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;

            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () => {s
                    var eventItem = new EventItem();
                    var eventPage = new EventDetailsPage();
                    eventPage.BindingContext = eventItem;
                    Navigation.PushAsync(eventPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", () => {
                    var eventItem = new EventItem();
                    var eventPage = new EventDetailsPage();
                    eventPage.BindingContext = eventItem;
                    Navigation.PushAsync(eventPage);
                }, 0, 0);
            }


            ToolbarItems.Add(tbi);

        }
    }
}
