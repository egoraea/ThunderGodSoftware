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
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            nameLabel.SetBinding(Label.TextProperty, "Name");

            var dateLabel = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            dateLabel.SetBinding(Label.TextProperty, "Date");

            var addrLabel = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            addrLabel.SetBinding(Label.TextProperty, "Address");

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { nameLabel,dateLabel,addrLabel }
            };

            View = layout;
        }
    }
}
