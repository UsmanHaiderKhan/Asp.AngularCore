using Asp.AngularCore.git.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Asp.AngularCore.git.Data
{
    public class LKRepository : ILKRepository
    {
        private readonly LKContext _context;

        public LKRepository(LKContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            using (_context)
            {
                return (from c in _context.Products
                    .OrderBy(m => m.Title)
                        select c).ToList();
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
    }
}
