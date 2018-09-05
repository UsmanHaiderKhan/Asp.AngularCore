using Asp.AngularCore.git.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;

namespace Asp.AngularCore.git.Controller
{
    [Route("api/[Controller]")]
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILKRepository _repository;
        private readonly ILogger<LKRepository> _logger;

        public OrderController(ILKRepository repository, ILogger<LKRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IActionResult GetOrder()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed To Get All Products:{e}");
                return null;
            }

        }
    }
}
