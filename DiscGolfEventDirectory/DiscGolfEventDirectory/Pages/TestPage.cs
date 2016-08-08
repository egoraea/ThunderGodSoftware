using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
namespace DiscGolfEventDirectory
{
	public class TestPage : ContentPage
	{

        List<Contact> list = new List<Contact>();
        ListView listView = new ListView();
        string test;
		public TestPage ()
		{
            try { 
            Console.Out.WriteLine("Hello");
            listView.IsPullToRefreshEnabled = true;
                listView.Refreshing += (sender, e) =>
                {
                    CognitoAWSCredentials credentials = new CognitoAWSCredentials("us-east-1:18ce3913-3574-441d-94f9-10a8f07ed105", RegionEndpoint.USEast1);
                    var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
                    DynamoDBContext context = new DynamoDBContext(client);
                    List<ScanCondition> conditions = new List<ScanCondition>();
                    var search = context.ScanAsync<Contact>(conditions);
                    search.GetNextSetAsync().ContinueWith(task =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            listView.ItemsSource = task.Result;
                        });
                    });
                    listView.IsRefreshing = false;
                };
            Title = "Test";
            test = "pol";
            databaseTest().ContinueWith(task =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        listView.ItemsSource = task.Result;
                    }
                    catch (Exception e)
                    {

                    }
                });
            }); ;
            Title = test;
			Content = new StackLayout {
				Children = {
					listView
				}
			};
        }
            catch (Exception e){
                Title = "error";
            }
}



        public Task<List<Contact>> databaseTest()
        {
            Console.Out.WriteLine("Hello");

            try
            {
                CognitoAWSCredentials credentials = new CognitoAWSCredentials("us-east-1:18ce3913-3574-441d-94f9-10a8f07ed105", RegionEndpoint.USEast1);
                var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
                DynamoDBContext context = new DynamoDBContext(client);
                List<ScanCondition> conditions = new List<ScanCondition>();
                object[] one =new object[1];
                one[0] = "1";
                conditions.Add(new ScanCondition("Id",ScanOperator.GreaterThan,one));
                var search = context.ScanAsync<Contact>(conditions);
                return search.GetNextSetAsync();
           }
            catch (Exception exception){
                Title = "error";
            }
            return null;
        }
    }
    [DynamoDBTable("discgolfdirectory-mobilehub-1705368074-Events")]
    public class Test
    {
        [DynamoDBHashKey]
        public int eventId { get; set; }

        [DynamoDBRangeKey]
        public string date { get; set; }
    }

    [DynamoDBTable("ContactList2")]
    public class Contact
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBRangeKey]
        public string UserId { get; set; }

        [DynamoDBProperty]
        public string FirstName { get; set; }

        [DynamoDBProperty]
        public string LastName { get; set; }

        [DynamoDBProperty]
        public int HomePhoneNumber { get; set; }

        [DynamoDBProperty]
        public int WorkPhoneNumber { get; set; }

        [DynamoDBProperty]
        public int MobileNumber { get; set; }

        [DynamoDBProperty]
        public string EmailAddress { get; set; }
    }
}
