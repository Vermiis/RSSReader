using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Class
{
    class InicializeDataBase
    {

        public void inicjalizeDataBase()
        {

         using (var ctx = new DataBase())
                {
                    Feeds Feed = new Feeds(1, new DateTime(2010,11,12),"Some feed", "Some description", "Some url" );
                    Category Ctg = new Category(1, "Some ctg");
                    User Us = new User(1, "Some");
                    IDUserIDCategory IDUIDC = new IDUserIDCategory(1, 1);

                    ctx.Feeds.Add(Feed);
                    ctx.IDUserIDCategory.Add(IDUIDC);
                    ctx.Category.Add(Ctg);
                    ctx.User.Add(Us);
            }
        }
    }
}
