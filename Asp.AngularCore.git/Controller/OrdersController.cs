﻿using Asp.AngularCore.git.Data;
using Asp.AngularCore.git.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;

namespace Asp.AngularCore.git.Controller
{
    [Route("api/[Controller]")]
    public class OrdersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILKRepository _repository;
        private readonly ILogger<LKRepository> _logger;

        public OrdersController(ILKRepository repository, ILogger<LKRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
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
                    return Ok(order);
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
        public IActionResult Post([FromBody]Order order)
        {
            try
            {
                _repository.AddNewOrder(order);
                if (_repository.SaveAll())
                {
                    return Created($"/api/orders/{order.Id}", order);
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
