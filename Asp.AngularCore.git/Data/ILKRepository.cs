using Asp.AngularCore.git.Data.Entities;
using System.Collections.Generic;

namespace Asp.AngularCore.git.Data
{
    public interface ILKRepository
    {
        List<Product> GetAllProducts();
        List<Product> GetProductsByCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeitems);
        Order GetOrderById(int id);
        void AddNewOrder(Order order);
    }
}
