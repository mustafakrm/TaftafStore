using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(item => item.ProductName).MinimumLength(2);
            RuleFor(item => item.ProductName).NotEmpty();
            RuleFor(item => item.SalePrice).NotEmpty();
            RuleFor(item => item.SalePrice).GreaterThan(0);

            RuleFor(item => item.ProductName).Must(StartWithTaftaf).WithMessage("Ürün İsmi 'Taftaf' ile başlamalı!!");

        }

        private bool StartWithTaftaf(string arg)
        {
            return arg.StartsWith("Taftaf");
        }
    }
}
