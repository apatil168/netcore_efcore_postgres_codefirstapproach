using Microsoft.AspNetCore.Mvc;
using Customer.Business.Dto;
using Customer.Business.Managers;

namespace Customer.Domain.Api.Controllers
{
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerManager _manager;

        public CustomerController(ICustomerManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Business.Dto.Customer customer)
        {
            var id = await _manager.Save(customer);
            customer.Id = id;
            return Ok(customer);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var customer = await _manager.GetById(userId);
            if(customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await _manager.Delete(userId);
            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(int userId, [FromBody] Business.Dto.Customer customer)
        {
            if (userId <= 0)
                return Problem(statusCode: 400, detail: $"user id must be greater than 0");
            var result = await _manager.Update(userId, customer);
            if (result == null)
                return Problem(statusCode: 500, detail: "An error ocurred when saving the customer.");

            return Ok(result);
        }
    }
}
