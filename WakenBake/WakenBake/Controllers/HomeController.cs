using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WakenBake.DAL;
using WakenBake.Models.Home;

namespace WakenBake.Controllers
{

    public class HomeController : Controller
    {
        dbWakenBakeEntities db = new dbWakenBakeEntities();

        public ActionResult Index()
        {

            return View();

                    
                      
        }
        public ActionResult BakerTable()
        {
            List<Tbl_Product> product = db.Tbl_Product.ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.PRODUCTS = product;
            return View(mymodel);
        }
        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product =db.Tbl_Product.Find(productId);
                foreach (var item in cart)
                {
                    if (item.Product.ProductId == productId)
                    {
                        int prevQty = item.Quantity;
                        if (prevQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = prevQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("Checkout");
        }
        

        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = db.Tbl_Product.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = db.Tbl_Product.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.ProductId == productId)
                    {
                        int prevQty = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.ProductId == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect( url);
        }
        public ActionResult RemoveFromCart(int ProductId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == ProductId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }
        public ActionResult Checkout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult CheckoutDetails()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
