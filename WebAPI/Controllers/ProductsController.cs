using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupled, interface bagımlı oldugu icin manager sınıfı degisse de kodumuz etkilenmez
        //naming convention
        //IoC ınversion of control (product service manager icin referans tutucu fakat bunu api katmanı cozumleyemez bu yüzden ioc yapisi kullanacagiz)
        //konfigürasyon oldugu icin .net kendisi giderek karsilik gelen bir container olup ulmadıgına karar verir
        //autofac ile alternatif yapıya tasındı.IoC
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //direkt result donerek frontendde daha anlasılr olabilir(result.data veya result.message gibi donebilirdi..)
            var result =  _productService.GetAll();
            if (result.Success)
            {
                return Ok( result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product) {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
