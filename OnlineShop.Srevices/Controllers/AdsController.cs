using Microsoft.AspNet.Identity;
using OnlineShop.Models;
using OnlineShop.Srevices.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


using System.Web.Http;


namespace OnlineShop.Srevices.Controllers
{
    [Authorize]
    public class AdsController : BaseApiController
    {
        [AllowAnonymous]
        [Route("api/ads")]
        public IHttpActionResult GetAds()
        {

            var ads = this.Data.Ads.OrderBy(a => a.Type.Name == "normal")
                .ThenBy(a => a.Type.Name == "diamond")
                .ThenBy(a => a.Type.Name == "diamond")
                .ThenBy(a => a.PostedOn)
                .Where(a => a.Status == AdStatus.Open)
                .Select(a => new AdViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Owner = new UserViewModel()
                    {
                        Id = a.Owner.Id,
                        UserName = a.Owner.UserName
                    },
                    Type = a.Type.Name,
                    DateOfPost = a.PostedOn,
                    Categories = a.Categories.Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                });

            return this.Ok(ads);
        }


        [Route("api/ads")]
        [HttpPost]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            var UserId = this.User.Identity.GetUserId();
            if (UserId == null)
            {
                return this.BadRequest("User need to be logged on!!!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("No data entry");
            }

            if (model.Categories.Count() > 3 || model.Categories.Count() < 0)
            {
                return this.BadRequest("categories can be no more than 3");

            }

            var cat = new List<Category>();
            foreach (var catId in model.Categories)
            {
                var DbCategories = Data.Categories
                    .FirstOrDefault(c => c.Id == catId);

                cat.Add(DbCategories);

                if (DbCategories == null)
                {
                    return this.BadRequest("this category does not exist");
                }
            }

            var ad = new Ad()
            {
                OwnerId = UserId,
                Name = model.Name,
                PostedOn = model.PostedOn,
                Description = model.Description,
                Price = model.Price,
                TypeId = model.TypeId,
                Categories = cat
            };

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();


            var result = this.Data.Ads.Where(a => a.Id == ad.Id)
             .Select(AdViewModel.Create).FirstOrDefault();


            return this.Ok(result);

        }

        [Route("api/ads/{id:int}/close")]
        [HttpPut]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads.FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return this.NotFound();
            }

            string userId = User.Identity.GetUserId();
            if (userId != ad.OwnerId)
            {
                return this.BadRequest("User is not Owner, cannot edit");
            }
            if (true)
            {
                ad.Status = AdStatus.Closed;
            }

            ad.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();

            return this.Ok();
        }

    }
}

