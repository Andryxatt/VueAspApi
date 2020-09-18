using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.Services;
using VueAsp.ViewModels.Order;

namespace VueAsp.Controllers
{
    public class OrderController : Controller
    {
        IRepositoryWrapper _repoWrapp;
        public OrderController(IRepositoryWrapper wrapper)
        {
            _repoWrapp = wrapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;//Equals to HTTPResponse 500
                return Json(new { responseText = "my error" });
            }
            Order order = new Order();
            var cart = SessionHelper.GetObjectFromJson<List<CartProduct>>(HttpContext.Session, "cart");
            OrderItems item = new OrderItems();

            //if (ModelState.IsValid)
            //{
            //    // Настройка конфигурации AutoMapper
            //    var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderViewModel, Order>()
            //        .ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName))
            //        .ForMember("Email", opt => opt.MapFrom(src => src.Address)));
            //    var mapper = new Mapper(config);
            //    // Выполняем сопоставление
            //    Order order = mapper.Map<OrderViewModel, Order>(model);
            //    _repoWrapp.Order.Create(order);
            //    _repoWrapp.Save();
            //    return Json("Ok");
            //}
            return Json("Ok");
        }
       
    }
}