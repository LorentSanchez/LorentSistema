using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Web.Data.Entities;
using Sistema.Web.Data.OrdenTemp;

namespace Sistema.Web.Data
{

    public class DataContext : DbContext
    {
        public DataContext() : base("name=SistemaF.Web")
        {

        }

        public DbSet<Sistema.Web.Data.Entities.Article> Article { get; set; }
        public DbSet<Sistema.Web.Data.Entities.ArticleClassification> ArticleClassification { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Brand> Brand { get; set; }
        public DbSet<Sistema.Web.Data.Entities.City> City { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Client_Classification> Client_Classification { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Company> Company { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Country> Country { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Customer> Customer { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Document> Document { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Employee> Employee { get; set; }
        public DbSet<Sistema.Web.Data.Entities.FormPago> FormPago { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Moneda> Moneda { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Neighborhood> Neighborhood { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Position> Position { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Seller> Seller { get; set; }
        public DbSet<Sistema.Web.Data.Entities.State> State { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Supplier> Supplier { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Company_Classification> Company_Classification { get; set; }
        public DbSet<Sistema.Web.Data.OrdenTemp.Order> Order { get; set; }
        public DbSet<Sistema.Web.Data.OrdenTemp.OrderDetail> OrderDetail { get; set; }

        public System.Data.Entity.DbSet<Sistema.Web.Data.Orden.ProductOrder> Articles { get; set; }
        // public DbSet<Sistema.Web.Data.Orden.OrdenStatud> OrdenStatuds { get; set; }


    }
}