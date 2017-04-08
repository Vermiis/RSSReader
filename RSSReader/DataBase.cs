using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Class
{
    class DataBase: DbContext
    {
        public DataBase(): base()
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Feeds> Feeds { get; set; }
        public DbSet<IDUserIDCategory> IDUserIDCategory { get; set; }
        public DbSet<User> User { get; set; }
    }
}
