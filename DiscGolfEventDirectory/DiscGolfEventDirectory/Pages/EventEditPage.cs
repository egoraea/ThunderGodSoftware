
using System;
using Xamarin.Forms;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
namespace DiscGolfEventDirectory
{
	public class EventEditPage : ContentPage
	{
        CognitoAWSCredentials credentials;
        AmazonDynamoDBClient client;
        DynamoDBContext context;

        public EventEditPage ()
		{

            credentials = new CognitoAWSCredentials("us-east-1:18ce3913-3574-441d-94f9-10a8f07ed105", RegionEndpoint.USEast1);
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
            context = new DynamoDBContext(client);

            Button saveButton = new Button()
            {
                Text = "Save",
                HorizontalOptions = LayoutOptions.Center
            };
            saveButton.Clicked += (sender, e) => {
                editClicked(sender,e);
            };

            Button deleteButton = new Button()
            {
                Text = "Delete",
                HorizontalOptions = LayoutOptions.Center
            };
            deleteButton.Clicked += (sender, e) => {
                deleteClicked(sender, e);
            };
            Entry nameDetails = new Entry()
            {
                FontAttributes = FontAttributes.Bold
            };
            nameDetails.SetBinding(Entry.TextProperty, "Name");


            Entry typeDetails = new Entry();
            typeDetails.SetBinding(Entry.TextProperty, "EventType");


            Entry dateDetails = new Entry();
            dateDetails.SetBinding(Entry.TextProperty, "StartDate");

            Entry endDetails = new Entry();
            endDetails.SetBinding(Entry.TextProperty, "EndDate");

            Entry dayDetails = new Entry();
            dayDetails.SetBinding(Entry.TextProperty, "DayOfWeek");

            Entry timeDetails = new Entry();
            timeDetails.SetBinding(Entry.TextProperty, "Time");

            Entry addrDetails = new Entry();
            addrDetails.SetBinding(Entry.TextProperty, "Location");

            Entry infoDetails = new Entry();
            infoDetails.SetBinding(Entry.TextProperty, "Notes");

            Entry registrationDetails = new Entry();
            registrationDetails.SetBinding(Entry.TextProperty, "EventRegistrationUrl");

            Entry frequencyDetails = new Entry();
            frequencyDetails.SetBinding(Entry.TextProperty, "Frequency");

            Entry linkDetails = new Entry();
            linkDetails.SetBinding(Entry.TextProperty, "EventUrl");

            Entry TDName = new Entry();
            TDName.SetBinding(Entry.TextProperty, "TD");

            Entry TdEmail = new Entry();
            TdEmail.SetBinding(Entry.TextProperty, "TdEmail");

            Entry TdPhoneNumber = new Entry();
            TdPhoneNumber.SetBinding(Entry.TextProperty, "TdPhoneNumber");

            Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};

		}

        async void editClicked(object sender, EventArgs e)
        {
            var answer = await DisplayActionSheet("Edit?", "Do you want to save these changes?", "Yes", "No");
            if (answer=="Yes")
            {
                context.SaveAsync<EventItem>(this.context);
            }
        }

        async void deleteClicked(object sender, EventArgs e)
        {
            var answer = await DisplayActionSheet("Delete?", "Are you sure you want to delete this event?", "Yes", "No");
            if (answer == "Yes")
            {

            }
        }
    }
}
