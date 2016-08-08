using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
namespace DiscGolfEventDirectory
{
    class EventListView :ListView
    {
        public List<EventItem> events;

        public EventListView()
        {
            this.IsPullToRefreshEnabled = true;
            RowHeight = 60;
            ItemTemplate = new DataTemplate(typeof(EventItemCell));

            this.Refreshing += (sender, e) =>
            {

                this.IsRefreshing = false;
            };
 
             this.ItemSelected += (sender, e) => {
                if (e.SelectedItem != null)
                {
                    var eventItem = (EventItem)e.SelectedItem;
                    var eventDetailsPage = new EventDetailsPage();
                    eventDetailsPage.BindingContext = eventItem;
                    Navigation.PushAsync(eventDetailsPage);
                    ((ListView)sender).SelectedItem = null;
                }
            };

        }

        public Task<List<Contact>> databaseTest()
        {

            try
            {
                CognitoAWSCredentials credentials = new CognitoAWSCredentials("us-east-1:18ce3913-3574-441d-94f9-10a8f07ed105", RegionEndpoint.USEast1);
                var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
                DynamoDBContext context = new DynamoDBContext(client);
                List<ScanCondition> conditions = new List<ScanCondition>();
                var search = context.ScanAsync<Contact>(conditions);
                return search.GetNextSetAsync();
            }
            catch (Exception e)
            {
            }
            return null;
        }
    
    public void sort()
        {
           
        }
    public void FilterEvents(string filter)
        {
            this.BeginRefresh();

            if (string.IsNullOrWhiteSpace(filter))
            {
                this.ItemsSource = events;
            }
            else
            {
                this.ItemsSource = events
                        .Where(x => x.Name.ToLower()
                           .Contains(filter.ToLower()));
            }

            this.EndRefresh();
        }
    }
}
