using DoAn_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnASP.Controllers
{
    public class ShoppingCartController : Controller
    {
        DataBase db = new DataBase();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //Phuong thuc Add item trong gio hang
        public ActionResult AddToCart(int id)
        {
            var pro = db.ProductCs.SingleOrDefault(s => s.Id == id);
            if (pro == null)
            {
                // You might want to handle the case where the product is not found
                return RedirectToAction("Index", "Home");
            }
            GetCart().Add(pro);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        //Trang Gio Hang
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id = int.Parse(form["Id"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity(id, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCartItem(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = t_item;
            return PartialView("BagCart");
        }
        
    }
}