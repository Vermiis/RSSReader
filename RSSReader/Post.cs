using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    public class Post
    {
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
        
        public Post(DateTime _PublishedDate, string _Description = "Description is unavable", string _Title = "Title is unavable", string _Link = null, string _ImageLink = null)
        {
            PublishedDate = _PublishedDate;
            Description = _Description;
            Title = _Title;
            Link = _Link;
            ImageLink = _ImageLink;
        }
    }
}
