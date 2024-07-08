using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_Nhom3.Models
{
    public class CartItem
    {
        public ProductC Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(ProductC pro, int quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.Product.Id == pro.Id);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    Product = pro,
                    Quantity = quantity,

                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void Update_Quantity(int id, int quantity)
        {
            var item = items.Find(s => s.Product.Id == id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }
        public double Totel_money()
        {
            var totel = items.Sum(s => s.Product.Price * s.Quantity);
            return (double)totel;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s.Product.Id == id);
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s.Quantity);
        }
    }
}