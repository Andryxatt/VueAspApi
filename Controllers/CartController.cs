using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.Services;
using VueAsp.ViewModels;
using VueAsp.ViewModels.Order;

namespace VueAsp.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        IRepositoryWrapper _repoWrapp;
        public CartController(IRepositoryWrapper wrapp, UserManager<User> userManager)
        {
            _repoWrapp = wrapp;
            _userManager = userManager;
        }
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.total = cart.Sum(item => item.Product.PriceBy * item.Quontity);
            }
            else
            {
                ViewBag.total = 0;
            }
            System.Security.Claims.ClaimsPrincipal User = this.User;
            OrderViewModel vm = new OrderViewModel();
            vm.User = _userManager.GetUserAsync(User).Result;
            vm.Products = cart;
            return View(vm);
        }
        [Route("cart/count")]
        public JsonResult GetCount()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            var count = 0;
            if (cart != null)
            {
                count = cart.Count();
            }
            return Json(count);
        }

        [Route("buy/{id}/{sizeId}")]
        [HttpPost]
        public JsonResult Buy(Guid id, Guid sizeId)
        {
            var count = 0;
            if (SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart") == null)
            {
                List<CartProduct> cart = new List<CartProduct>();
                cart.Add(new CartProduct { Product = _repoWrapp.Product.GetProductById(id), Quontity = 1 , SelectedSize = _repoWrapp.SizePorduct.GetProdSizeById(sizeId)});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                count = 1;
            }
            else
            {
                List<CartProduct> cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");

                int index = isExistWithSize(id,sizeId);
                if (index != -1)
                {
                    cart[index].Quontity++;
                }
                else
                {
                    cart.Add(new CartProduct { Product = _repoWrapp.Product.GetProductById(id), Quontity = 1 , SelectedSize = _repoWrapp.SizePorduct.GetProdSizeById(sizeId) });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                count = cart.Sum(p => p.Quontity);
            }
            return Json(count);
        }

        [Route("remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            List<CartProduct> cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(Guid id)
        {
            List<CartProduct> cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public JsonResult Quontity(Guid prodId, Guid sizeId, int count, bool operation, Guid Id)
        {
            var prod = _repoWrapp.SizePorduct.FindByCondition(f => f.ProductId == prodId && f.SizeId == sizeId).FirstOrDefault();
            var cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            int index = isExistWithSize(prodId, sizeId);
            if (operation == true)
            {
                if (prod.Count > count)
                {
                    count++;
                    cart[index].Quontity++;
                }
             
            }
            else if (count > 1 && operation == false)
            {
                count--;
                cart[index].Quontity--;
            }
             var total = cart.Sum(item => item.Product.PriceBy * item.Quontity);
            var price = cart[index].Quontity * cart[index].Product.PriceSalleUS;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Json(new { count, total, price });
        }
        private int isExistWithSize(Guid id, Guid sizeId)
        {
            List<CartProduct> cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id) && cart[i].SelectedSize.SizeId.Equals(sizeId))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}