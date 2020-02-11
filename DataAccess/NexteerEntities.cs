using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public partial class NexteerEntities
    {
        public static Dictionary<int, string> GetAllProductNames()
        {
            Dictionary<int, string> products = new Dictionary<int, string>();

            using (var context = new NexteerEntities())
            {
                foreach (DataAccess.Product p in context.Products.OrderBy(p => p.Name).ToList())
                {
                    products.Add(p.ProductID, p.Name);
                }
            }

            return products;
        }
        public static Product GetProductByID(int ProductID)
        {
            Product product = new Product();

            using (var context = new NexteerEntities())
            {
                product = context.Products.Where(p => p.ProductID == ProductID).FirstOrDefault<Product>();
                if (product.ProductSubcategoryID != null)
                {
                    context.Entry(product).Reference(psc => psc.ProductSubcategory).Load();
                    context.Entry(product.ProductSubcategory).Reference(psc => psc.ProductCategory).Load();
                }
            }

            return product;
        }
        public static bool AddProduct(Product Product)
        {
            try
            {
                using (var context = new NexteerEntities())
                {
                    Product.rowguid = Guid.NewGuid();
                    Product.ModifiedDate = DateTime.Now;
                    context.Products.Add(Product);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
            
        }
        public static bool ModifyProduct(Product Product)
        {
            try
            {
                using (var context = new NexteerEntities())
                {
                    Product productExisting = context.Products.Where(p => p.ProductID == Product.ProductID).FirstOrDefault<Product>();
                    var attachedEntry = context.Entry(productExisting);
                    Product.rowguid = Guid.NewGuid();
                    Product.ModifiedDate = DateTime.Now;
                    attachedEntry.CurrentValues.SetValues(Product);
                    context.SaveChanges();
                }

                return true;

            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static bool DeleteProduct(int ProductID)
        {
            try
            {
                using (var context = new NexteerEntities())
                {
                    Product product = new Product { ProductID = ProductID };
                    context.Products.Attach(product);
                    context.Products.Remove(product);
                    context.SaveChanges();
                }

                return true;

            }
            catch (Exception error)
            {
                return false;
            }


        }
        public static IEnumerable<ProductSubcategory> GetProductSubcategories()
        {
            IEnumerable<ProductSubcategory> productSubcategories = new List<ProductSubcategory>();

            using (var context = new NexteerEntities())
            {
                productSubcategories = context.ProductSubcategories.OrderBy(psc => psc.Name).ToList();
            }

            return productSubcategories;
        }
    }
}
