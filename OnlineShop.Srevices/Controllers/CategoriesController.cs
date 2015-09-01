using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShop.Srevices.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public IHttpActionResult GetCategory()
        {
            var categoriesId = Data.Categories.Select(c => new
            {
                name = c.Name,
                id = c.Id
            });
           
            return this.Ok(categoriesId);

        }

    }
}
