using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopDemo.Abstraction;
using WebShopDemo.Data;

namespace WebShopDemo.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;
        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public int CountClients()
        {
            return _context.Products.Count();
        }
        public int CountOrders()
        {
            return _context.Orders.Count();
        }

        // Връща броя на потребителите на приложението без админа
        public int CountProducts()
        {
            return _context.Users.Count() - 1;
        }

        //връща общата печалба от направените поръчки
        public decimal SumOrders()
        {
            return _context.Orders.Sum(x => x.Quantity * x.Price - x.Quantity * x.Price * x.Discount / 100);
        }
    }
}
