using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Finance.Model
{
    public class Item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Image { get; set; }
    }

    public class Posts
    {
        public ObservableCollection<Item> Items { get; set; }
    }
}
