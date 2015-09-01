using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineShop.Models;

namespace OnlineShop.Srevices.Models
{
    public class CreateAdBindingModel
    {

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int TypeId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }


        //public int OwnerId { get; set; }

        [Required]
        public IEnumerable<int> Categories
        { get; set; }
    }
}