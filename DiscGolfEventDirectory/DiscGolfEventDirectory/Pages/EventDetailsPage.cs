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

            Label nameDetails = new Label()
            {
                FontAttributes = FontAttributes.Bold
            };
            nameDetails.SetBinding(Label.TextProperty, "Name");


            Label typeDetails = new Label();
            typeDetails.SetBinding(Label.TextProperty, "EventType");
 
            
            Label dateDetails = new Label();
            dateDetails.SetBinding(Label.TextProperty, "StartDate");

            Label endDetails = new Label();
            endDetails.SetBinding(Label.TextProperty, "EndDate");

            Label dayDetails = new Label();
            dayDetails.SetBinding(Label.TextProperty, "DayOfWeek");

            Label timeDetails = new Label();
            timeDetails.SetBinding(Label.TextProperty, "Time");

            Label addrDetails = new Label();
            addrDetails.SetBinding(Label.TextProperty, "Location");

            Label infoDetails = new Label();
            infoDetails.SetBinding(Label.TextProperty, "Notes");

            Label registrationDetails = new Label();
            registrationDetails.SetBinding(Label.TextProperty, "EventRegistrationUrl");

            Label frequencyDetails = new Label();
            frequencyDetails.SetBinding(Label.TextProperty, "Frequency");

            Label linkDetails = new Label();
            linkDetails.SetBinding(Label.TextProperty, "EventUrl");

            Label TDName = new Label();
            TDName.SetBinding(Label.TextProperty, "TD");

            Label TdEmail = new Label();
            TdEmail.SetBinding(Label.TextProperty, "TdEmail");

            Label TdPhoneNumber = new Label();
            TdPhoneNumber.SetBinding(Label.TextProperty, "TdPhoneNumber");

            ToolbarItem edit = new ToolbarItem("Edit", "edit", () => {
                EventEditPage settingPage = new EventEditPage();
                Navigation.PushAsync(settingPage);
            }, 0, 0);

            ToolbarItems.Add(edit);
            Label mapLink = new Label();
            Content = new StackLayout {
				Children = {
                    eventMap,
					nameDetails,
                    typeDetails,
                    dateDetails,
                    addrDetails,
                    infoDetails,
                    linkDetails,
                    mapLink
				}
			};
		}

    }
}
