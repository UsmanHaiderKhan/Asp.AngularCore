using Asp.AngularCore.git.Data;
using Asp.AngularCore.git.Data.Entities;
using Asp.AngularCore.git.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.AngularCore.git.Controller
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILKRepository _repository;
        private readonly ILogger<LKRepository> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<StoreUser> _userManager;

        public OrdersController(ILKRepository repository,
            ILogger<LKRepository> logger,
            IMapper mapper,
            UserManager<StoreUser> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Get(bool includeitems = true)
        {
            try
            {
                var username = User.Identity.Name;
                var result = _repository.GetOrderByUser(username, includeitems);
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
                var order = _repository.GetOrderById(User.Identity.Name, id);
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
        public async Task<IActionResult> Post([FromBody]OrderViewModel model)
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

                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    neworder.User = currentUser;

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
