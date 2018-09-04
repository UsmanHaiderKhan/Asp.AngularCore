using Asp.AngularCore.git.Data.Entities;
using System.Collections.Generic;

namespace Asp.AngularCore.git.Data
{
    public interface ILKRepository
    {
        List<Product> GetAllProducts();
        List<Product> GetProductsByCategory(string category);
        bool SaveChanges();
    }
}
