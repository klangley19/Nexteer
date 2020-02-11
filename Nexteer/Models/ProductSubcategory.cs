using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexteer.Models
{
    public class ProductSubcategory : IProductSubcategory
    {
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual IProductCategory ProductCategory { get; set; }
        public virtual ICollection<IProduct> Products { get; set; }

        public IEnumerable<ProductSubcategory> GetProductSubcategories()
        {
            List<DataAccess.ProductSubcategory> productSubcategories = DataAccess.NexteerEntities.GetProductSubcategories().ToList();
            List<ProductSubcategory> data = new List<Models.ProductSubcategory>();

            foreach (DataAccess.ProductSubcategory psc in productSubcategories)
            {
                ProductSubcategory newPSC = new ProductSubcategory();
                newPSC.ProductSubcategoryID = psc.ProductSubcategoryID;
                newPSC.Name = psc.Name;
                data.Add(newPSC);
            }

            return data;
        }
        public IEnumerable<SelectListItem> GetProductSubcategoriesSelectList(IEnumerable<ProductSubcategory> ProductSubcategories)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (ProductSubcategory psc in ProductSubcategories)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = psc.Name;
                sli.Value = psc.ProductSubcategoryID.ToString();
                selectListItems.Add(sli);
            }

            return selectListItems;
        }
    }
}