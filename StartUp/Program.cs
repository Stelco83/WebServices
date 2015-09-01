using OnlineShop.Data;
using OnlineShop.Data.Migrations;
using System;
using System.Data.Entity;
using System.Linq;

namespace StartUp
{
    class Program
    {
        static void Main()
        {

            //var migstrat = new MigrateDatabaseToLatestVersion<OnlineShopContext, Configuration>();
            //Database.SetInitializer(migstrat);

            var context = new OnlineShopContext();
            //var booksCount = context.Ads.CountAsync();
            //Console.WriteLine(booksCount);

       
                var cat = context.Categories.Select(c => new
                {
                    id = c.Id,
                    name = c.Name
                });
                foreach (var categoryId in cat)
                {
                    Console.WriteLine();
                }
                

        }
    }
}
