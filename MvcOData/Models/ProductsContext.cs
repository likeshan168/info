using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MvcOData.Models
{
    public class ProductsContext:DbContext
    {
        public ProductsContext()
            : base("ProductsContext")
        { 
        
        }

        public DbSet<Product> Products { get; set; }
    }
}