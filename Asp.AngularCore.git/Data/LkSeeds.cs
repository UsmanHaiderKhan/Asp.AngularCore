using Asp.AngularCore.git.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.AngularCore.git.Data
{
    public class LkSeeds
    {
        private readonly LKContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _user;


        public LkSeeds(LKContext context, IHostingEnvironment hosting, UserManager<StoreUser> user)
        {
            _context = context;
            _hosting = hosting;
            _user = user;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            var userEmail = await _user.FindByEmailAsync("usmanhaiderkhan4@gmail.com");

            if (userEmail == null)
            {
                userEmail = new StoreUser()
                {
                    FirstName = "Usman",
                    LastName = "Khan",
                    Email = "usmanhaiderkhan4@gmail.com",
                    UserName = "Usman@hotmail.com"
                };
                var result = await _user.CreateAsync(userEmail, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed To Add Default User");
                }
            }



            if (!_context.Products.Any())
            {
                var file = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(file);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _context.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "12345",

                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,

                            UnitPrice = products.First().Price
                        }
                    }
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }
    }
}
