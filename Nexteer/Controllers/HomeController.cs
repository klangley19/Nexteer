using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Nexteer.Models;

namespace Nexteer.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ProductSubcategory psc = new ProductSubcategory();
            List<ProductSubcategory> productSubcategories = psc.GetProductSubcategories().ToList();
            ViewBag.ProductSubcategoriesSelectList = psc.GetProductSubcategoriesSelectList(productSubcategories);

            return View();
        }

        public ActionResult ViewProducts()
        {
            Product product = new Product();
            Dictionary<int, string> products = product.GetAllProducts();
            return View(products);
        }
        public ActionResult ViewProductDetails(int ProductID)
        {
            Product product = new Product();
            product = product.GetProductByID(ProductID);
            return View(product);
        }

        public ActionResult AddProduct()
        {
            ProductSubcategory psc = new ProductSubcategory();
            List<ProductSubcategory> productSubcategories = psc.GetProductSubcategories().ToList();
            List<SelectListItem> items = psc.GetProductSubcategoriesSelectList(productSubcategories).ToList();
            items.Insert(0, new SelectListItem { Text = "Select Product Subcategory", Value = "0" });
            ViewBag.ProductSubcategoriesSelectList = items;

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product Product)
        {
            if (ModelState.IsValid)
            {
                if (Product.AddProduct(Product))
                {
                    return RedirectToAction("ProductAddedSuccess");
                }
                else
                {
                    return RedirectToAction("ProductAddedFailed");
                }

            }
            return View();
        }

        public ActionResult ProductAddedSuccess()
        {
            return View();
        }
        public ActionResult ProductAddedFailed()
        {
            return View();
        }


        public ActionResult EditProduct(int ProductID)
        {
            Product product = new Product();
            product = product.GetProductByID(ProductID);

            ProductSubcategory psc = new ProductSubcategory();
            List<ProductSubcategory> productSubcategories = psc.GetProductSubcategories().ToList();
            List<SelectListItem> items = psc.GetProductSubcategoriesSelectList(productSubcategories).ToList();
            items.Insert(0, new SelectListItem { Text = "", Value = "0" });
            ViewBag.ProductSubcategoriesSelectList = items;

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product Product)
        {
            if (ModelState.IsValid)
            {
                if (Product.ModifyProduct(Product))
                {
                    return RedirectToAction("ProductModifiedSuccess");
                }
                else
                {
                    return RedirectToAction("ProductModifiedFailed");
                }
            }
            return View();
        }


        public ActionResult ProductModifiedSuccess()
        {
            return View();
        }
        public ActionResult ProductModifiedFailed()
        {
            return View();
        }


        public ActionResult DeleteProduct(int ProductID)
        {
            Product p = new Product();
            if (p.DeleteProduct(ProductID))
            {
                return RedirectToAction("ProductDeletedSuccess");
            }
            else
            {
                return RedirectToAction("ProductDeletedFailed");
            }
        }

        public ActionResult ProductDeletedSuccess()
        {
            return View();
        }
        public ActionResult ProductDeletedFailed()
        {
            return View();
        }

    }
}