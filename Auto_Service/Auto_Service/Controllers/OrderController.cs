﻿using Auto_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Auto_Service.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            List<Order> list = new List<Order>();
            using (OrdersContext sc = new OrdersContext())
            {
                list = sc.Orders.ToList();
            }
            return View(list);
        }

        public ActionResult Manage()
        {
            List<Order> list = new List<Order>();
            using (OrdersContext sc = new OrdersContext())
            {
                list = sc.Orders.ToList();
            }
            return View(list);
        }

        public ActionResult My()
        {
            List<Order> list = new List<Order>();
            string owner = User.Identity.GetUserName();
            using (OrdersContext sc = new OrdersContext())
            {
                list = sc.Orders.Where(x => x.Owner == owner).ToList();
            }
            return View(list);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            using (OrdersContext sc = new OrdersContext())
            {
                sc.Orders.Add(order);
                sc.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            int int_id = Convert.ToInt32(id);
            using (OrdersContext sc = new OrdersContext())
            {
                var order = sc.Orders.First<Order>(x => x.Id == int_id);
                return View(order);
            }
        }

        [HttpPost]
        public ActionResult Edit(Order model)
        {
            using (OrdersContext db = new OrdersContext())
            {
                Order oldOrder = db.Orders.First<Order>(x => x.Id == model.Id);
                
                oldOrder.Title = model.Title;
                oldOrder.Description = model.Description;
                oldOrder.PostTime = DateTime.Now.ToString();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(string id)
        {
            int int_id = Convert.ToInt32(id);
            using (OrdersContext sc = new OrdersContext())
            {
                var order = sc.Orders.First<Order>(x => x.Id == int_id);
                return View(order);
            }
        }

        public ActionResult Delete(string id)
        {
            int int_id = Convert.ToInt32(id);
            using (OrdersContext sc = new OrdersContext())
            {
                var order = sc.Orders.First<Order>(x => x.Id == int_id);
                return View(order);
            }
        }

        [HttpPost]
        public ActionResult Delete(Order model)
        {
            using (OrdersContext sc = new OrdersContext())
            {
                Order order = sc.Orders.First<Order>(x => x.Id == model.Id);

                sc.Orders.Remove(order);
                sc.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}

