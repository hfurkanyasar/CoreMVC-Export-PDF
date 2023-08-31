using CoreMVCExportPDF.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCExportPDF.Controllers
{
  
    public class ProductController : Controller
    {
        private hfyContext Context;
        
        public ProductController(hfyContext _context)
        {
            this.Context = _context;
        }

        public IActionResult Index()
        {
            var prod = this.Context.Products.ToList();
            return View(prod);
        }

        [HttpPost]
        public FileResult ExportProduct()
        {
            var prod = this.Context.Products.ToList();

            string[] propertyNames = { "ProductID", "ProductName", "UnitPrice", "UnitsInStock" };
            string[] columnHeaders = { "ProductID", "ProductName", "UnitPrice", "UnitsInStock" };

            return MyMethotClass.GeneratePDF(prod, propertyNames, columnHeaders);
        }
    }
}
