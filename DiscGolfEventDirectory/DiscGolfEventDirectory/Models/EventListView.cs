using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
namespace DiscGolfEventDirectory
{
    class EventListView :ListView
    {
        public List<EventItem> events;

        public EventListView()
        {
            RowHeight = 60;
            ItemTemplate = new DataTemplate(typeof(EventItemCell));

            this.ItemSelected += (sender, e) => {
                if (e.SelectedItem != null)
                {
                    var eventItem = (EventItem)e.SelectedItem;
                    var eventDetailsPage = new EventDetailsPage();
                    eventDetailsPage.BindingContext = eventItem;
                    Navigation.PushAsync(eventDetailsPage);
                    ((ListView)sender).SelectedItem = null;
                }
            };

        }

        public void FilterEvents(string filter)
        {
            this.BeginRefresh();

            if (string.IsNullOrWhiteSpace(filter))
            {
                this.ItemsSource = events;
            }
            else
            {
                this.ItemsSource = events
                        .Where(x => x.Name.ToLower()
                           .Contains(filter.ToLower()));
            }

            this.EndRefresh();
        }
    }
}
