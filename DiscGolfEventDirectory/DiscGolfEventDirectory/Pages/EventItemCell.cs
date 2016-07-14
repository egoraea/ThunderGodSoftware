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
                FontSize = 24,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            nameLabel.SetBinding(Label.TextProperty, "Name");

            var dateLabel = new Label
            {
                FontSize = 14,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,  
            };

            dateLabel.SetBinding(Label.TextProperty, "Date", stringFormat: "{0:h:mm tt MM/dd/yy}");

            var addrLabel = new Label
            {
                FontSize = 12,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            addrLabel.SetBinding(Label.TextProperty, "Address");

            var iconLabel = new Image
            {
                HeightRequest = 60,
                WidthRequest = 60,
                HorizontalOptions = LayoutOptions.Start,
                Source = "league.png",
                IsVisible = true,
                
            };

            var typeLabel = new Label
            {
                FontSize = 12,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            typeLabel.SetBinding(Label.TextProperty, "Type");

            //iconLabel.SetBinding(Image.SourceProperty, "Type".ToUpper());
           
            var leftLayout = new StackLayout
            {
                Padding = new Thickness(0, 0, 20, 0),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { nameLabel,typeLabel},
            };

            var distLabel = new Label
            {
                FontSize = 14,

                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            
            distLabel.SetBinding(Label.TextProperty, "Distance", stringFormat: "{0:F1} miles away");

            var rightLayout = new StackLayout {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { dateLabel,distLabel }
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(0, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                Children = { iconLabel, leftLayout, rightLayout }
            };
            View = layout;
        }


    }
}
