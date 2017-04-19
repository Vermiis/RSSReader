using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    [Table("Feeds Url")]
    class UserIDUrlID
    {
        [Key]
        public int UserID { get; set; }
        public int UrlID { get; set; }

        UserIDUrlID(int _UserID, int _UrlID)
        {
            UserID = _UserID;
            UrlID = _UrlID;
        }
    }
}