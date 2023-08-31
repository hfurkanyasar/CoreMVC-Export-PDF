using CoreMVCExportPDF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCExportPDF.Context
{
    public class hfyContext : DbContext
    {
        public hfyContext(DbContextOptions<hfyContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
