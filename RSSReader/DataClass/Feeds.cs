using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    [Table("Feeds")]
    class Feeds
    {
        [Key]
        public int FeedID { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageLink { get; set; }

        public Feeds(int _FeedID, int _CategoryID, DateTime _Date, string _Title, string _Description, string _Url, string _ImageLink)
        {
            FeedID = _FeedID;
            CategoryID = _CategoryID;
            Date = _Date;
            Title = _Title;
            Description = _Description;
            Url = _Url;
            ImageLink = _ImageLink;
        }
    }
}
