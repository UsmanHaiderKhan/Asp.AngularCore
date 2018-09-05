using Asp.AngularCore.git.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;

namespace Asp.AngularCore.git.Controller
{
    [Route("api/[Controller]")]
    public class ProductsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILKRepository _repository;
        private readonly ILogger<LKRepository> _logger;

        public ProductsController(ILKRepository repository, ILogger<LKRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to Get the Products:{e}");
                return BadRequest("Failed ");
            }

        }

    }
}
