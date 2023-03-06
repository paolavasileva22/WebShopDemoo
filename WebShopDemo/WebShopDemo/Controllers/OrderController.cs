<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShopDemo.Data;
using WebShopDemo.Domain;
using WebShopDemo.Models.Order;

namespace WebShopDemo.Controllers
{
<<<<<<< HEAD
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //Razglejdane na vs.poruchki
        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.SingleOrDefault(u => u.Id == userId);
            List<OrderIndexVM> orders = context
            .Orders
            .Select(x => new OrderIndexVM
=======
    [Authorize(Roles = "Administrator")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            this._context = context;
        }
        // GET: OrderController

        public ActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            List<OrderIndexVM> orders = _context.Orders.Select(x => new OrderIndexVM
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
            {
                Id = x.Id,
                OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                UserId = x.UserId,
                User = x.User.UserName,
                ProductId = x.ProductId,
                Product = x.Product.ProductName,
                Picture = x.Product.Picture,
                Quantity = x.Quantity,
                Price = x.Price,
                Discount = x.Discount,
                TotalPrice = x.TotalPrice,
            }).ToList();
            return View(orders);
        }
<<<<<<< HEAD

        //Pokazva samo poruchkite na potrebitel i tursi po ime na product
        public IActionResult MyOrders(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
=======
        [AllowAnonymous]
        public IActionResult MyOrders(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == currentUserId);
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
            if (user == null)
            {
                return null;
            }
<<<<<<< HEAD
            List<OrderIndexVM> orders = context
            .Orders
            .Where(x => x.UserId == user.Id)
            .Select(x => new OrderIndexVM
=======
            List<OrderIndexVM> orders = _context.Orders.Where(x => x.UserId == user.Id).Select(x => new OrderIndexVM
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
            {
                Id = x.Id,
                OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                UserId = x.UserId,
                User = x.User.UserName,
                ProductId = x.ProductId,
                Product = x.Product.ProductName,
                Picture = x.Product.Picture,
                Quantity = x.Quantity,
                Price = x.Price,
                Discount = x.Discount,
                TotalPrice = x.TotalPrice,
            }).ToList();
<<<<<<< HEAD

=======
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.Product.ToLower().Contains(searchString.ToLower())).ToList();
            }
<<<<<<< HEAD
            return View(orders);
        }

        //Raboti na GET zaqvka predlaga potvurjdenie na product
        public ActionResult Create(int productId, int quantity)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
            var product = this.context.Products.SingleOrDefault(x => x.Id == productId);
=======
            return this.View(orders);

        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        [AllowAnonymous]
        public ActionResult Create(int productId, int quantity)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var product = this._context.Products.SingleOrDefault(x => x.Id == productId);
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5

            if (user == null || product == null || product.Quantity < quantity)
            {
                return this.RedirectToAction("Index", "Product");
            }
            OrderConfirmVM orderForDb = new OrderConfirmVM
            {
<<<<<<< HEAD
                // Id = x.Id,
=======
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
                UserId = userId,
                User = user.UserName,
                ProductId = productId,
                ProductName = product.ProductName,
                Picture = product.Picture,
<<<<<<< HEAD

=======
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
                Quantity = quantity,
                Price = product.Price,
                Discount = product.Discount,
                TotalPrice = quantity * product.Price - quantity * product.Price * product.Discount / 100
            };
            return View(orderForDb);
        }

<<<<<<< HEAD
        //POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderConfirmVM bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
                var product = this.context.Products.SingleOrDefault(x => x.Id == bindingModel.ProductId);

                if (user == null || product == null || product.Quantity < bindingModel.Quantity || bindingModel.Quantity == 0)
=======
        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(OrderConfirmVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _context.Users.SingleOrDefault(u => u.Id == userId);
                var product = this._context.Products.SingleOrDefault(x => x.Id == bindingModel.ProductId);

                if (user == null || product == null || bindingModel.Quantity < bindingModel.Quantity || bindingModel.Quantity == 0)
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
                {
                    return this.RedirectToAction("Index", "Product");
                }
                Order orderForDb = new Order
                {
<<<<<<< HEAD
                    // Id = x.Id,
=======
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
                    OrderDate = DateTime.UtcNow,
                    ProductId = bindingModel.ProductId,
                    UserId = userId,
                    Quantity = bindingModel.Quantity,
                    Price = product.Price,
                    Discount = product.Discount,
                };
<<<<<<< HEAD

                product.Quantity -= bindingModel.Quantity;

                this.context.Products.Update(product);
                this.context.Orders.Add(orderForDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Product");
        }
=======
                product.Quantity -= bindingModel.Quantity;
                this._context.Products.Update(product);
                this._context.Orders.Add(orderForDb);
                this._context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Product");
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
    }
}
