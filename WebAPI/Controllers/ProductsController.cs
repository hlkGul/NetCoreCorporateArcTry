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
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            var result =  _productService.GetAll();
            return result.Data;
        }
    }
}
