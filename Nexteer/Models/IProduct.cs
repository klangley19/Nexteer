using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexteer.Models
{
    public interface IProduct
    {
        int ProductID { get; set; }
        string Name { get; set; }
        string ProductNumber { get; set; }
        bool MakeFlag { get; set; }
        bool FinishedGoodsFlag { get; set; }
        string Color { get; set; }
        short SafetyStockLevel { get; set; }
        short ReorderPoint { get; set; }
        decimal StandardCost { get; set; }
        decimal ListPrice { get; set; }
        string Size { get; set; }
        string SizeUnitMeasureCode { get; set; }
        string WeightUnitMeasureCode { get; set; }
        Nullable<decimal> Weight { get; set; }
        int DaysToManufacture { get; set; }
        string ProductLine { get; set; }
        string Class { get; set; }
        string Style { get; set; }
        Nullable<int> ProductSubcategoryID { get; set; }
        Nullable<int> ProductModelID { get; set; }
        System.DateTime SellStartDate { get; set; }
        Nullable<System.DateTime> SellEndDate { get; set; }
        Nullable<System.DateTime> DiscontinuedDate { get; set; }
        System.Guid rowguid { get; set; }
        System.DateTime ModifiedDate { get; set; }

        IProductSubcategory ProductSubcategory { get; set; }

        Dictionary<int, string> GetAllProducts();
        Product GetProductByID(int ProductID);
        bool AddProduct(Product Product);
        bool ModifyProduct(Product Product);
        bool DeleteProduct(int ProductID);
    }
}
