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
            var get = context.CreateBatchGet<Test>();
            Test retrievedBook = await context.LoadAsync<Test>(1);
            test = retrievedBook.date;
            await get.ExecuteAsync();
            list = get.Results;
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
}
