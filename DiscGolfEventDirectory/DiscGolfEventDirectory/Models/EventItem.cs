using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
//using SQLite;

namespace DiscGolfEventDirectory
{
    class EventItem
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
    }
}
