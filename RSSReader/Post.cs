using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    public class Post
    {
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }

        public Post(string _PublishedDate = "1995-01-01 00:00:00", string _Description = "Description is unavable", string _Title = "Title is unavable", string _Link = null, string _ImageLink = null)
        {
            PublishedDate = _PublishedDate;
            Description = _Description;
            Title = _Title;
            Link = _Link;
            ImageLink = _ImageLink;
        }
    }
}
