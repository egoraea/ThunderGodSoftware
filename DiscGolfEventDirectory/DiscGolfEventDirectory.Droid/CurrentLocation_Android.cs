using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Maps;

namespace DiscGolfEventDirectory.Droid
{
    class CurrentLocation_Android: ICurrentLocation
    {
        public Position getCurrentLocation()
        {
            throw new NotImplementedException();
        }

    }
}