using CoreMVCExportPDF.Context;
using CoreMVCExportPDF.Entities;
using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMVCExportPDF.Controllers
{
    public class DenemeController : Controller
    {
        private hfyContext Context;
        public DenemeController(hfyContext _context)
        {
            this.Context = _context;
        }

        public IActionResult Index()
        {

            var customers = this.Context.Customers.ToList();
            return View(customers);

        }

        [HttpPost]
        public FileResult ExportCustomer()
        {
            var customers = this.Context.Customers.ToList();

            string[] propertyNames = { "CustomerID", "ContactName", "City", "Country" };
            string[] columnHeaders = { "CustomerID", "ContactName", "City", "Country" };

            return MyMethotClass.GeneratePDF(customers, propertyNames, columnHeaders);
        }
     
        

    }
}
