using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShop.Srevices.Models
{
    public class AdViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual string Type { get; set; }

        public DateTime? DateOfPost { get; set; }

        public UserViewModel Owner { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public static Expression<Func<Ad, AdViewModel>> Create
        {
            get
            {
                return ad => new AdViewModel()
                {
                    Owner = new UserViewModel()
                    {
                        Id = ad.Owner.Id,
                        UserName = ad.Owner.UserName
                    },

                    Categories = ad.Categories
                    .Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }),

                    Price = ad.Price,
                    Description = ad.Description,
                    Type = ad.Type.Name,
                    Name = ad.Name,
                    Id = ad.Id,
                    DateOfPost = ad.PostedOn
                };

            }
        }

        
    }
}
