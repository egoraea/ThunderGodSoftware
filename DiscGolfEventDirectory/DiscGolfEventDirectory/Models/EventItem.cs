using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Amazon.DynamoDBv2.DataModel;
//using SQLite;

namespace DiscGolfEventDirectory
{
    [DynamoDBTable("DGschedulerEvents")]
    class EventItem : IComparable
    {
        public EventItem()
        {
        }

        [DynamoDBHashKey]
        public int Id { get; set; }

        [DynamoDBProperty]
        public string Name { get; set; }

        [DynamoDBRangeKey]
        public string EventType { get; set; }

        [DynamoDBProperty]
        public string DayOfWeek { get; set; }

        [DynamoDBProperty]
        public string EndDate { get; set; }

        [DynamoDBProperty]
        public string EventRegistrationUrl { get; set; }

        [DynamoDBProperty]
        public string EventUrl { get; set; }

        [DynamoDBProperty]
        public string Frequency { get; set; }

        [DynamoDBProperty]
        public string Location { get; set; }

        [DynamoDBProperty]
        public string Notes { get; set; }

        [DynamoDBProperty]
        public string StartDate { get; set; }

        [DynamoDBProperty]
        public string TD { get; set; }

        [DynamoDBProperty]
        public string TdEmail { get; set; }

        [DynamoDBProperty]
        public string TdPhoneNumber { get; set; }

        [DynamoDBProperty]
        public string Time { get; set; }
        public double Distance { get; set; }


        public int CompareTo(Object obj)
        {

            EventItem e = (EventItem)obj;
            if(this.Distance > e.Distance)
                return 1;
            return -1;
        }
    }
}
