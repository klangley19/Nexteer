using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nexteer.Models
{
    public interface IProductSubcategory
    {
        int ProductSubcategoryID { get; set; }
        int ProductCategoryID { get; set; }
        string Name { get; set; }
        System.Guid rowguid { get; set; }
        System.DateTime ModifiedDate { get; set; }

        IProductCategory ProductCategory { get; set; }
        ICollection<IProduct> Products { get; set; }

        IEnumerable<ProductSubcategory> GetProductSubcategories();
        IEnumerable<SelectListItem> GetProductSubcategoriesSelectList(IEnumerable<ProductSubcategory> ProductSubcategories);
    }
}
