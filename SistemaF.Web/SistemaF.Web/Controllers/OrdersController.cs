using Sistema.Web.Data;
using Sistema.Web.Data.Entities;
using Sistema.Web.Data.Orden;
using Sistema.Web.Data.OrdenTemp;
using Sistema.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SistemaF.Web.Controllers
{
    public class OrdersController : Controller
    {

        DataContext db = new DataContext();


        public ActionResult NewOrder()
        {
            var orderview = new OrderView();
            orderview.customer = new Customer();
            orderview.Products = new List<ProductOrder>();
            Session["orderview"] = orderview;

            var list = db.Customer.ToList();
            list.Add(new Customer { Customer_Id = 0, NombreC = "[Seleccione un Cliente..]" });
            list = list.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClientID = new SelectList(list, "Customer_Id", "NombreCompleto");
            return View();
        }
        [HttpPost]
        public ActionResult NewOrder(OrderView orderview)
        {
            orderview = Session["orderview"] as OrderView;

            var Customer_Id = int.Parse(Request["Customer_Id "]);
            if (Customer_Id == 0)
            {
                var list = db.Customer.ToList();
                list.Add(new Customer { Customer_Id = 0, NombreC = "[Seleccione un Cliente..]" });
                list = list.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.Customer = new SelectList(list, "Customer_Id", "NombreC ompleto");
                ViewBag.Error = "Debe seleccionar un cliente.";


                return View(orderview);
            }

            var Customer = db.Customer.Find(Customer_Id);
            if (Customer == null)
            {
                var list = db.Customer.ToList();
                list.Add(new Customer { Customer_Id = 0, NombreC = "[Seleccione un Cliente..]" });
                list = list.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.Customer_Id = new SelectList(list, "Customer_Id", "NombreCompleto");
                ViewBag.Error = "Cliente no existe.";

                return View(orderview);
            }
            if (orderview.Products.Count == 0)
            {
                var list = db.Customer.ToList();
                list.Add(new Customer { Customer_Id = 0, NombreC = "[Seleccione un Cliente..]" });
                list = list.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.Customer_Id = new SelectList(list, "Customer_Id", "NombreCompleto");
                ViewBag.Error = "Debes ingresar un detalle.";
                return View(orderview);
            }


            int orderID = 0;


            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        Customers = Customer,
                        OrderDate = DateTime.Now,
                        OrderStatuds = OrdenStatud.Created
                    };
                    db.Order.Add(order);
                    db.SaveChanges();

                    orderID = db.Order.ToList().Select(o => o.OrderID).Max();



                    foreach (var item in orderview.Products)
                    {
                        var orderDetail = new OrderDetail
                        {
                            ArtC_Id = item.Article_Id,
                            Descripcion = item.Article_Name,
                            OrderPrice = (int)item.Price,
                            Cantidad = item.Quantity,
                            OrderID = orderID,

                        };
                        db.OrderDetail.Add(orderDetail);
                        db.SaveChanges();
                    }



                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    ViewBag.Error = "Error: " + ex.Message;
                    return View(orderview);
                }


            }
            ViewBag.Message = string.Format("La orden: {0}, grabada ok", orderID);

            var listC = db.Customer.ToList();
            listC.Add(new Customer { Customer_Id = 0, NombreC = "[Seleccione un Cliente..]" });
            listC = listC.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.Customer = new SelectList(listC, "Customer_Id", "NombreCompleto");

            orderview = new OrderView();
            orderview.customer = new Customer();
            orderview.Products = new List<ProductOrder>();
            Session["orderview"] = orderview;


            return View(orderview);
        }
        public ActionResult AddProduct()
        {
            var list = db.Article.ToList();
            list.Add(new ProductOrder { Article_Id = 0, Article_Name = "[Seleccione un Producto...]" });
            list = list.OrderBy(c => c.Article_Name).ToList();
            ViewBag.ArtC_Id = new SelectList(list, "ArtC_Id", "Article_Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductOrder ProductOrder)
        {
            var orderview = Session["orderview"] as OrderView;

            var Article_Id = int.Parse(Request["Artic_Id"]);
            if (Article_Id == 0)
            {
                var list = db.Article.ToList();
                list.Add(new ProductOrder { Article_Id = 0, Article_Name = "[Seleccione un Producto...]" });
                list = list.OrderBy(c => c.Article_Name).ToList();
                ViewBag.Artic_Id = new SelectList(list, "Artic_Id", "Article_Name");
                ViewBag.Error = "Debe seleccionar un Producto.";

                return View(ProductOrder);
            }

            var Article = db.Article.Find(Article_Id);
            if (Article == null)
            {
                var list = db.Article.ToList();
                list.Add(new ProductOrder { Article_Id = 0, Article_Name = "[Seleccione un Producto...]" });
                list = list.OrderBy(c => c.Article_Name).ToList();
                ViewBag.Article = new SelectList(list, "Artic_Id", "Article_Name");
                ViewBag.Error = "el producto no existe.";

                return View(ProductOrder);
            }

            ProductOrder = orderview.Products.Find(p => p.Article_Id == Article_Id);
            if (ProductOrder == null)
            {
                ProductOrder = new ProductOrder
                {
                    Article_Name = Article.Article_Name,
                    Price = Article.Price,
                    Article_Id = Article.Article_Id,
                    Quantity = float.Parse(Request["Quantity"])

                };
                orderview.Products.Add(ProductOrder);
            }
            else
            {
                ProductOrder.Quantity += float.Parse(Request["Quantity"]);
            }
            var listC = db.Customer.ToList();
            listC.Add(new Customer { Customer_Id = 0, NombreC = "[Seleccione un Cliente..]" });
            listC = listC.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClientID = new SelectList(listC, "ClientID", "FullName");
            return View("NewOrder", orderview);


        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

