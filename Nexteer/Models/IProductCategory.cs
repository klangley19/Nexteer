using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexteer.Models
{
    public interface IProductCategory
    {
        int ProductCategoryID { get; set; }
        string Name { get; set; }
        System.Guid rowguid { get; set; }
        System.DateTime ModifiedDate { get; set; }

        ICollection<IProductSubcategory> ProductSubcategories { get; set; }
    }
}
