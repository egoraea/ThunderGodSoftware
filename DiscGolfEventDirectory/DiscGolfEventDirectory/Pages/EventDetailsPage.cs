using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DiscGolfEventDirectory
{
	public class EventDetailsPage : ContentPage
	{
		public EventDetailsPage()
		{
            //Geocoder geo = new Geocoder();
            // var location = Location();
            Map eventMap;
            try
            {
                eventMap = new Map(new MapSpan(new Position(57, 62), 30, 30))
                {
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                eventMap.MapType = MapType.Street;
            }
            catch
            {
                eventMap = new Map();
            }
            this.SetBinding(ContentPage.TitleProperty, "Name");

            NavigationPage.SetHasNavigationBar(this, true);

            var nameDetails = new Label()
            {
                FontAttributes = FontAttributes.Bold
            };
            nameDetails.SetBinding(Label.TextProperty, "Name");


            var typeDetails = new Label();
            typeDetails.SetBinding(Label.TextProperty, "Type");
 
            var dataDetails = new Label();
            dataDetails.SetBinding(Label.TextProperty, "Date");

            var addrDetails = new Label();
            addrDetails.SetBinding(Label.TextProperty, "Address");

            var infoDetails = new Label();
            infoDetails.SetBinding(Label.TextProperty, "Information");

            var linkDetails = new Label();
            linkDetails.SetBinding(Label.TextProperty, "Website");

            var mapLink = new Label();
            Content = new StackLayout {
				Children = {
                    eventMap,
					nameDetails,
                    typeDetails,
                    dataDetails,
                    addrDetails,
                    infoDetails,
                    linkDetails,
                    mapLink
				}
			};
		}

        public async Task<IEnumerable<Position>> Location()
        {
            Geocoder geo = new Geocoder();
            IEnumerable<Position> location = await geo.GetPositionsForAddressAsync("615 Oyster Shell Ct Missouri City, Texas 77459");
            return location;
        }

        public static double DistanceBetween(Position a, Position b)
        {
            double d = Math.Acos(
               (Math.Sin(a.Latitude) * Math.Sin(b.Latitude)) +
               (Math.Cos(a.Latitude) * Math.Cos(b.Latitude))
               * Math.Cos(b.Longitude - a.Longitude));

            return 6378137 * d;
        }
    }
}
