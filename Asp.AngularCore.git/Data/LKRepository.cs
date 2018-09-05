using Asp.AngularCore.git.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.AngularCore.git.Data
{
    public class LKRepository : ILKRepository
    {
        private readonly LKContext _context;
        private readonly ILogger<LKRepository> _logger;

        public LKRepository(LKContext context, ILogger<LKRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("We call the All Products");
                using (_context)
                {
                    return (from c in _context.Products
                            .OrderBy(m => m.Title)
                            select c).ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to Get All Products:{e}");
                return null;
            }

        }

        public List<Product> GetProductsByCategory(string category)
        {
            using (_context)
            {
                return (from c in _context.Products
                    .Where(c => c.Category == category)
                        select c).ToList();
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(m => m.Items).ThenInclude(m => m.Product).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include(m => m.Items)
                .ThenInclude(m => m.Product)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }
    }
}
