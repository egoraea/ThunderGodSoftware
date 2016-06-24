using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace DiscGolfEventDirectory
{
    class EventItemCell : ViewCell
    {
        public EventItemCell()
        {
            var nameLabel = new Label
            {
                FontSize = 16,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            nameLabel.SetBinding(Label.TextProperty, "Name");

            var dateLabel = new Label
            {
                FontSize = 10,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,  
            };

            dateLabel.SetBinding(Label.TextProperty, "Date", stringFormat: "{0:h:mm tt MM/dd/yy}");

            var addrLabel = new Label
            {
                FontSize = 10,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            addrLabel.SetBinding(Label.TextProperty, "Address");

            var leftLayout = new StackLayout
            {
                Padding = new Thickness(0, 10, 20, 10),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { nameLabel,dateLabel,addrLabel }
            };

            var distLabel = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            
            distLabel.SetBinding(Label.TextProperty, "Distance", stringFormat: "{0:F1}");

            var distLayout = new StackLayout {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { distLabel, new Label {Text = "miles away"} }
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Horizontal,
                Children = { leftLayout, distLayout }
            };
            View = layout;
        }


    }
}
