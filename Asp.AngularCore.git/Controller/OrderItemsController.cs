using Asp.AngularCore.git.Data;
using Asp.AngularCore.git.Data.Entities;
using Asp.AngularCore.git.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Asp.AngularCore.git.Controller
{
    [Route("/api/orders/{orderid}/items")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILKRepository _repository;
        private readonly ILogger<LKRepository> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(ILKRepository repository,
            ILogger<LKRepository> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrderById(User.Identity.Name, orderId);
            if (order != null)
            {
                return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {

            var order = _repository.GetOrderById(User.Identity.Name, orderId);
            if (order != null)
            {
                var item = order.Items.Where(o => o.Id == orderId).FirstOrDefault();
                if (item != null)
                {
                    return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(item));
                }

            }

            return NotFound();
        }
    }
}
