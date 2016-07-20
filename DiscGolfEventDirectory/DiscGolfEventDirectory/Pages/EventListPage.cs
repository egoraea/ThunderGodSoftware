using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Amazon.DynamoDBv2;

namespace DiscGolfEventDirectory
{
	public class EventListPage : ContentPage
	{

    EventListView listView;
        public EventListPage ()
		{
            Title = "Events";

            // var locator = CrossGeolocator.Current;
            // Position xamarinPost = getLocation().Result;
            List<EventItem> events = new List<EventItem>();
           /* locator.PositionChanged += (sender, e) => {
                var position = e.Position;
                xamarinPost = new Position(e.Position.Latitude,e.Position.Longitude);
                foreach(EventItem eve in events)
                {
                    eve.Distance = DistanceBetween(xamarinPost,eve.Coordinates);
                }
                events.Sort();
                listView.ItemsSource = null;
                listView.ItemsSource = events;
            };*/
            //listView.ItemsSource = events;

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new EventListView();
            events.Add(new EventItem
            {
                Name = "Buy ptears`",
                Address = "123 Apple STreet",
                Date = new DateTime(1993, 12, 12),
                Information = "You buy pears with your discs",
                Type = "mini.png",
                Distance = 3.4,
                Coordinates = new Position(32.2, 45.0)
            });
            events.Add(new EventItem
            {
                Name = "Buy not pears`",
                Address = "123 Apple STreet",
                Date = new DateTime(1993, 12, 12),
                Information = "You buy pears with your discs",
                Type = "league.png",
                Distance = 4.3,
                Coordinates = new Position(52.2, 35.0)
            });
            Position xamarinPost = new Position(12,14);
            foreach (EventItem eve in events)
            {
                eve.Distance = DistanceBetween(xamarinPost, eve.Coordinates);
            }

            events.Sort();
            listView.ItemsSource = null;
            listView.ItemsSource = events;
            listView.events = events;

            var layout = new StackLayout();
            SearchBar searchBar = new SearchBar();
            searchBar.Placeholder = "Search";
            searchBar.TextChanged += (sender, e) => listView.FilterEvents(searchBar.Text);
            searchBar.SearchButtonPressed += (sender, e) => {
                listView.FilterEvents(searchBar.Text);
            };

            layout.Children.Add(searchBar);
            layout.Children.Add(listView);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;
            searchBar.IsVisible = false;
           

            ToolbarItem settings = null;
            ToolbarItem search = null;

            if (Device.OS == TargetPlatform.iOS)
            {
                settings = new ToolbarItem("Settings", null, () => {
                    var settingPage = new SettingPage();
                    Navigation.PushAsync(settingPage);
                }, 0, 0);
            }



            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                settings = new ToolbarItem("Settings", "setting", () => {
                    var settingPage = new SettingPage();
                    Navigation.PushAsync(settingPage);
                }, 0, 0);
                search = new ToolbarItem("Search", "search", () => {
                    searchBar.IsVisible = !searchBar.IsVisible;
                }, 0, 0);
            }

            ToolbarItems.Add(search);

            ToolbarItems.Add(settings);

        }


        /*
                public void FilterLocations(string filter)
                {
                    this.BeginRefresh();

                    if (string.IsNullOrWhiteSpace(filter))
                    {
                        this.ItemsSource = locations;
                    }
                    else
                    {
                        this.ItemsSource = locations
                            .Where(x => x.Title.ToLower()
                           .Contains(filter.ToLower()));
                    }

                    this.EndRefresh();
                }
                */
        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            getLocation().ContinueWith(task =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    listView.ItemsSource = task.Result;
                });
            });
        }*/

        public async Task<Position> getLocation()
        {
            var locator = CrossGeolocator.Current;
            Plugin.Geolocator.Abstractions.Position location = null;
            try
            {
                location = await locator.GetPositionAsync(timeoutMilliseconds: 1);
            }
            catch
            {
                Console.WriteLine("failed");
            }
            Position result = new Position(location.Latitude, location.Longitude);
            return result;
        }

        public static double DistanceBetween(Position a, Position b)
        {
            double d = Math.Acos(
               (Math.Sin(a.Latitude) * Math.Sin(b.Latitude)) +
               (Math.Cos(a.Latitude) * Math.Cos(b.Latitude))
               * Math.Cos(b.Longitude - a.Longitude));

            return 6378137 * d/ 1609.34;
        }

    }
}
