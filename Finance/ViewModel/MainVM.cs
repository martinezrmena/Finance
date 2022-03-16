using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Finance.Model;
using Xamarin.Forms;

namespace Finance.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public Posts Blog
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            ReadRss();
        }

        public void ReadRss()
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(Posts));

            //using (WebClient client = new WebClient())
            //{
            //    string xml = Encoding.Default.GetString(client.DownloadData("https://www.finzen.mx/blog-feed.xml"));
            //    using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            //    {
            //        Blog = (Posts)serializer.Deserialize(reader);
            //    }
            //}

            Blog = new Posts();
            Blog.Items = new ObservableCollection<Item>()
            {
                new Item()
                {
                    Title = "Imagen 1",
                    Description = "Description of image 1",
                    Image = ImageSource.FromResource("Finance.Images.img1.jpeg")
                },
                new Item()
                {
                    Title = "Imagen 2",
                    Description = "Description of image 2",
                    Image = ImageSource.FromResource("Finance.Images.img2.jpeg")
                }
            };
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
