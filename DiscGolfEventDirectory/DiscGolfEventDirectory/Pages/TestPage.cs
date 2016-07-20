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
using Amazon.DynamoDBv2.Model;
namespace DiscGolfEventDirectory
{
	public class TestPage : ContentPage
	{
        List<Test> list;
        string test;
		public TestPage ()
		{
            Title = "Test";

            databaseTest();
            Title = test;
            ListView listView = new ListView();
            listView.ItemsSource = list;
			Content = new StackLayout {
				Children = {
					listView
				}
			};
		}


        public async void databaseTest()
        {
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(
    "us-east-1_ySCFNqvfA", // Your identity pool ID
    RegionEndpoint.USEast1 // Region
);

            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();

            var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
            DynamoDBContext context = new DynamoDBContext(client);
            Dictionary<string, AttributeValue> values = new Dictionary<string, AttributeValue>();
            var get = context.CreateBatchGet<Test>();
            Test retrievedBook = await context.LoadAsync<Test>(1);
            test = retrievedBook.date;
            await get.ExecuteAsync();
            list = get.Results;
            Test createdBook = new Test
            {
                eventId = 5,
                date = "safg"
            };
            List<ScanCondition> conditions = new List<ScanCondition>();
            context.ScanAsync<Test>(conditions);
            var search = context.ScanAsync<Test>(conditions);
           list = await search.GetNextSetAsync();
            await context.SaveAsync(createdBook);
        }
    }
    [DynamoDBTable("Events")]
    public class Test
    {
        [DynamoDBHashKey]
        public int eventId { get; set; }

        [DynamoDBRangeKey]
        public string date { get; set; }
    }
}
