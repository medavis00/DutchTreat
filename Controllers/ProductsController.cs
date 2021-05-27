using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IDutchRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //  start but doesn't work with try/catch returning null
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{    
        //    return _repository.GetAllProducts();
        //}

        // next add try/catch
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    try
        //    {
        //        return Json(_repository.GetAllProducts());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get products: {ex}");
        //        return Json("Bad Request");
        //    }
        //}

        // third - let requester determine the return type
        // returns status codes
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(_repository.GetAllProducts());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get products: {ex}");
        //        return BadRequest("Bad Request - failed to get products");
        //    }
        //}

        // 4th - change controller to controllerbase, IAction to action
        // removes the need for OK
        // add attribute apicontroller above and
        // the following  - helps self document
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Bad Request - failed to get products");
            }
        }


    }
}
