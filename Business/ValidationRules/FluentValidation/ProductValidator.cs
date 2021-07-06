using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //kurallar constructorlar icerisine yazılacak DTO nesneleri icin de fluent val uygulanabilir
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //herhangi bir kategoriye gore de fluent validation yapabiliriz
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //bu sekilde bulunmayan kuralları kendimiz yazabiliriz. StartWithA bizim kendi yazacak oldugumuz method
            //with message ile kendi hata mesajımızı ekleyebilriz. 
            //RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("urunler a harfi ile baslamalı");

        }
        //arg parametresi bizim gondermis oldugumuz productname
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
