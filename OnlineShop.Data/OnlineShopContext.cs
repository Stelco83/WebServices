namespace OnlineShop.Data
{
    using System.Data.Entity;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using Migrations;
    using System;

    public class OnlineShopContext : IdentityDbContext<ApplicationUser>
    {
       
        public OnlineShopContext()
            : base("OnlineShopContext")
        {
      
        }

        public virtual DbSet<Ad> Ads { get; set; }

        public virtual DbSet<AdType> AdTypes { get; set; }

        public virtual DbSet<Category> Categories { get; set; }


        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    
  
}