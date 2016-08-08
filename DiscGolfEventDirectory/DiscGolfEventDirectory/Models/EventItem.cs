using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Amazon.DynamoDBv2.DataModel;
//using SQLite;

namespace DiscGolfEventDirectory
{
    [DynamoDBTable("")]
    class EventItem:IComparable
    {
        public EventItem()
        {
        }
  //      [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public Position Coordinates { get; set; }

        public double Distance { get; set; }
        public string Information { get; set; }
        public string Website { get; set; }

        public int CompareTo(Object obj)
        {

            EventItem e = (EventItem)obj;
            if(this.Distance > e.Distance)
                return 1;
            return -1;
        }
    }
}
