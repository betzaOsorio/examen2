using CartApp.Core.Discounts.Interfaces;
using CartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Discounts
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly IEnumerable<IDiscountRule> _reglasDescuento;
        public DiscountCalculator(IEnumerable<IDiscountRule> reglasDescuento)
        {
            _reglasDescuento = reglasDescuento;
        }
        public decimal Calculate(decimal montoSubtotal, DiscountsDTO contextoDescuentos)
        {
            decimal descuentoTotal = 0m;
            foreach (var regla in _reglasDescuento)
            {
                descuentoTotal += regla.CalculateDiscount(montoSubtotal, contextoDescuentos);
            }
            return descuentoTotal;
        }
    }
}
