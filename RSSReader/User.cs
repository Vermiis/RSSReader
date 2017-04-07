using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    [Table("User")]
    class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }

        public User(int _UserID, string _UserName)
        {
            UserID = _UserID;
            UserName = UserName;
        }
    }
}
