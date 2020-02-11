using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using DataAccess;

namespace Nexteer.Models
{
    public class Product : IProduct
    {
        public int ProductID { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "A Product Name is required")]
        [StringLength(50, ErrorMessage = "The maximum length for Product Name is 50 characters")]
        public string Name { get; set; }

        [DisplayName("Product Number")]
        [Required(ErrorMessage = "A Product Number is required")]
        [StringLength(25, ErrorMessage = "The maximum length for Product Number is 25 characters")]
        public string ProductNumber { get; set; }

        [DisplayName("Make Flag")]
        [Required(ErrorMessage = "A Make Flag is required")]
        [ValidBoolean(ErrorMessage = "Not able to convert Make Flag entry to a true/false value.")]
        public bool MakeFlag { get; set; }

        [DisplayName("Finished Goods Flag")]
        [Required(ErrorMessage = "A Finished Goods Flag is required")]
        [ValidBoolean(ErrorMessage = "Not able to convert Finished Goods Flag entry to a true/false value.")]
        public bool FinishedGoodsFlag { get; set; }

        [DisplayName("Color")]
        [StringLength(15, ErrorMessage = "The maximum length for Color is 15 characters")]
        public string Color { get; set; }

        [DisplayName("Safety Stock Level")]
        [Required(ErrorMessage = "A Safety Stock Level is required")]
        [Range(0, 32767)]
        public short SafetyStockLevel { get; set; }

        [DisplayName("Reorder Point")]
        [Required(ErrorMessage = "A Reorder Point is required")]
        [Range(0, 32767)]
        public short ReorderPoint { get; set; }

        [DisplayName("Standard Cost")]
        [Required(ErrorMessage = "A Standard Cost is required")]
        [Range(0, 2000000000000)]
        public decimal StandardCost { get; set; }

        [DisplayName("List Price")]
        [Required(ErrorMessage = "A List Price is required")]
        [Range(0, 2000000000000)]
        public decimal ListPrice { get; set; }

        [DisplayName("Size")]
        [StringLength(5, ErrorMessage = "The maximum length for Size is 5 characters")]
        public string Size { get; set; }

        [DisplayName("Size Unit Measure Code")]
        [StringLength(3, ErrorMessage = "The maximum length for Size Unit Measure Code is 3 characters")]
        public string SizeUnitMeasureCode { get; set; }

        [DisplayName("Weight Unit Measure Code")]
        [StringLength(3, ErrorMessage = "The maximum length for Weight Unit Measure Code is 3 characters")]
        public string WeightUnitMeasureCode { get; set; }

        [DisplayName("Weight")]
        [Range(0, 999999)]
        public Nullable<decimal> Weight { get; set; }

        [DisplayName("Days To Manufacture")]
        [Required(ErrorMessage = "A Days To Manufacture is required")]
        [Range(0, 2147483647)]
        public int DaysToManufacture { get; set; }

        [DisplayName("Product Line")]
        [StringLength(2, ErrorMessage = "The maximum length for Product Line is 2 characters")]
        public string ProductLine { get; set; }

        [DisplayName("Class")]
        [StringLength(2, ErrorMessage = "The maximum length for Class is 2 characters")]
        public string Class { get; set; }

        [DisplayName("Style")]
        [StringLength(2, ErrorMessage = "The maximum length for Style is 2 characters")]
        public string Style { get; set; }

        [DisplayName("ProductSubcategoryID")]
        [Range(0, 2147483647)]
        public Nullable<int> ProductSubcategoryID { get; set; }

        [DisplayName("ProductModelID")]
        [Range(0, 2147483647)]
        public Nullable<int> ProductModelID { get; set; }

        [DisplayName("Sell Start Date")]
        [Required(ErrorMessage = "A Sell Start Date is required")]
        [ValidDate(ErrorMessage = "Not able to convert Sell Start Date entry to a date value.")]
        public System.DateTime SellStartDate { get; set; }

        [DisplayName("Sell End Date")]
        [ValidDate(ErrorMessage = "Not able to convert Sell End Date entry to a date value.")]
        public Nullable<System.DateTime> SellEndDate { get; set; }

        [DisplayName("Discontinued Date")]
        [ValidDate(ErrorMessage = "Not able to convert Discontinued Date entry to a date value.")]
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }

        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual IProductSubcategory ProductSubcategory { get; set; }

        public Product()
        {
            this.ProductSubcategory = new ProductSubcategory();
            this.ProductSubcategory.ProductCategory = new ProductCategory();
        }


        public Dictionary<int, string> GetAllProducts()
        {
            return NexteerEntities.GetAllProductNames();
        }
        public Product GetProductByID(int ProductID)
        {
            DataAccess.Product product = NexteerEntities.GetProductByID(ProductID);
            return this.CopyEntityProductOver(product);
        }
        public bool AddProduct(Product Product)
        {
            DataAccess.Product product = this.CopyEntityProductOver(Product);
            return DataAccess.NexteerEntities.AddProduct(product);
        }
        public bool ModifyProduct(Product Product)
        {
            DataAccess.Product product = this.CopyEntityProductOver(Product);
            return DataAccess.NexteerEntities.ModifyProduct(product);
        }
        public bool DeleteProduct(int ProductID)
        {
            return DataAccess.NexteerEntities.DeleteProduct(ProductID);
        }

        private Nexteer.Models.Product CopyEntityProductOver(DataAccess.Product Product)
        {
            Nexteer.Models.Product p = new Product();
            p.ProductID = Product.ProductID;
            p.Name = Product.Name;
            p.ProductNumber = Product.ProductNumber;
            p.MakeFlag = Product.MakeFlag;
            p.FinishedGoodsFlag = Product.FinishedGoodsFlag;
            p.Color = Product.Color;
            p.SafetyStockLevel = Product.SafetyStockLevel;
            p.ReorderPoint = Product.ReorderPoint;
            p.StandardCost = Product.StandardCost;
            p.ListPrice = Product.ListPrice;
            p.Size = Product.Size;
            p.SizeUnitMeasureCode = Product.SizeUnitMeasureCode;
            p.WeightUnitMeasureCode = Product.WeightUnitMeasureCode;
            p.Weight = Product.Weight;
            p.DaysToManufacture = Product.DaysToManufacture;
            p.ProductLine = Product.ProductLine;
            p.Class = Product.Class;
            p.Style = Product.Style;
            p.ProductSubcategoryID = Product.ProductSubcategoryID;
            p.ProductModelID = Product.ProductModelID;
            p.SellStartDate = Product.SellStartDate;
            p.SellEndDate = Product.SellEndDate;
            p.DiscontinuedDate = Product.DiscontinuedDate;
            if (Product.ProductSubcategory != null)
            {
                p.ProductSubcategory.Name = Product.ProductSubcategory.Name;
            }
            if (Product.ProductSubcategory != null && Product.ProductSubcategory.ProductCategory != null)
            {
                p.ProductSubcategory.ProductCategory.Name = Product.ProductSubcategory.ProductCategory.Name;
            }

            return p;
        }
        private DataAccess.Product CopyEntityProductOver(Nexteer.Models.Product Product)
        {
            DataAccess.Product p = new DataAccess.Product();
            p.ProductID = Product.ProductID;
            p.Name = Product.Name;
            p.ProductNumber = Product.ProductNumber;
            p.MakeFlag = Product.MakeFlag;
            p.FinishedGoodsFlag = Product.FinishedGoodsFlag;
            p.Color = Product.Color;
            p.SafetyStockLevel = Product.SafetyStockLevel;
            p.ReorderPoint = Product.ReorderPoint;
            p.StandardCost = Product.StandardCost;
            p.ListPrice = Product.ListPrice;
            p.Size = Product.Size;
            p.SizeUnitMeasureCode = Product.SizeUnitMeasureCode;
            p.WeightUnitMeasureCode = Product.WeightUnitMeasureCode;
            p.Weight = Product.Weight;
            p.DaysToManufacture = Product.DaysToManufacture;
            p.ProductLine = Product.ProductLine;
            p.Class = Product.Class;
            p.Style = Product.Style;
            if (Product.ProductSubcategoryID == null || Product.ProductSubcategoryID == 0)
            {
                p.ProductSubcategoryID = null;
            }
            else
            {
                p.ProductSubcategoryID = Product.ProductSubcategoryID;
            }
            p.ProductModelID = Product.ProductModelID;
            p.SellStartDate = Product.SellStartDate;
            p.SellEndDate = Product.SellEndDate;
            p.DiscontinuedDate = Product.DiscontinuedDate;
            if (Product.ProductSubcategory != null && Product.ProductSubcategory.Name != null)
            {
                p.ProductSubcategory.Name = Product.ProductSubcategory.Name;
            }
            if (Product.ProductSubcategory != null && Product.ProductSubcategory.ProductCategory != null && Product.ProductSubcategory.ProductCategory.Name != null)
            {
                p.ProductSubcategory.ProductCategory.Name = Product.ProductSubcategory.ProductCategory.Name;
            }

            return p;
        }
    }
}