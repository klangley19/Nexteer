using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nexteer.Models
{
    public class ProductCategory : IProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<IProductSubcategory> ProductSubcategories { get; set; }
    }
}