using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicProductsApi
{
    public class Product
    {
        public Product()
        {

        }
        public Product(int id, string name, string description, int? price, bool inStock) :this()
        {
            ProductId = id;
            Name = name;
            Description = description;
            Price = price;
            InStock = inStock;
        }

        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public bool InStock { get; set; }
    }
}
