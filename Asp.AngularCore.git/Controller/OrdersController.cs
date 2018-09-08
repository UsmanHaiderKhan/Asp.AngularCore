using Asp.AngularCore.git.Data;
using Asp.AngularCore.git.Data.Entities;
using Asp.AngularCore.git.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Asp.AngularCore.git.Controller
{
    [Route("api/[Controller]")]
    public class OrdersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILKRepository _repository;
        private readonly ILogger<LKRepository> _logger;
        private readonly IMapper _mapper;

        public OrdersController(ILKRepository repository,
            ILogger<LKRepository> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get(bool includeitems = true)
        {
            try
            {
                var result = _repository.GetAllProducts(includeitems);
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(result));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed To Get All Products:{e}");
                return BadRequest("Failed to Get the Orders");
            }

        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                if (order != null)
                    return Ok(_mapper.Map<Order, OrderViewModel>(order));
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed To Get All Products:{e}");
                return BadRequest("Failed to Get the Orders");
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var neworder = _mapper.Map<OrderViewModel, Order>(model);
                    if (neworder.OrderDate == DateTime.MinValue)
                    {
                        neworder.OrderDate = DateTime.Now;
                    }
                    _repository.AddNewOrder(neworder);
                    if (_repository.SaveAll())
                    {

                        return Created($"/api/orders/{neworder.Id}", _mapper.Map<Order, OrderViewModel>(neworder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to Post the Product:{e}...! :)");

            }

            return BadRequest("Failed To Added");
        }
    }
}
