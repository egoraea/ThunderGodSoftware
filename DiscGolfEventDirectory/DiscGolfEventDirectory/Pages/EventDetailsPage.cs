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
            Geocoder geo = new Geocoder();
            var location = Location();
            var eventMap = new Map(new MapSpan(new Position(57,62), 360, 360) );
            eventMap.MapType = MapType.Street;

            this.SetBinding(ContentPage.TitleProperty, "Name");

            NavigationPage.SetHasNavigationBar(this, true);
            var nameLabel = new Label { Text = "Name:" };
            var nameDetails = new Label();
            nameDetails.SetBinding(Label.TextProperty, "Name");

            var typeLabel = new Label { Text = "Type:" };
            var typeDetails = new Label();
            typeDetails.SetBinding(Label.TextProperty, "Type");
            var dataLabel = new Label { Text = "Date:" };
            var dataDetails = new Label();
            dataDetails.SetBinding(Label.TextProperty, "Date");
            var addrLabel = new Label { Text = "Address:" };
            var addrDetails = new Label();
            addrDetails.SetBinding(Label.TextProperty, "Address");
            var infoLabel = new Label { Text = "Information:" };
            var infoDetails = new Label();
            infoDetails.SetBinding(Label.TextProperty, "Information");
            Content = new StackLayout {
				Children = {
                    eventMap,
					nameLabel,nameDetails,
                    typeLabel,typeDetails,
                    dataLabel,dataDetails,
                    addrLabel,addrDetails,
                    infoLabel,infoDetails
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
