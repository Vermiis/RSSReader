using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    [Table("Category")]
    class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category(int _CategoryID, string _CategoryName)
        {
            CategoryID = _CategoryID;
            CategoryName = _CategoryName;
        }
    }
}
