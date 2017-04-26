using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    [Table("ID user ID category")]
    class IDUserIDCategory
    {
        [Key]
        public int UserID { get; set; }
        public int CategoryID { get; set; }

        public IDUserIDCategory(int _UserID, int _CategoryID)
        {
            UserID = _UserID;
            CategoryID = _CategoryID;
        }
    }
}
