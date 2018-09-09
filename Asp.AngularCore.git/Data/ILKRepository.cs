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
        IEnumerable<Order> GetOrderByUser(string username, bool includeitems);
        Order GetOrderById(string username, int id);
        void AddNewOrder(Order order);

    }
}
