using CartApp.Core.Discounts.Interfaces;
using CartApp.Models;
using CartApp.Settings.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Discounts
{
    public class CouponDiscountRule : IDiscountRule
    {
        private readonly IConfigsDTO _configuracion;
        public CouponDiscountRule(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }

        public decimal CalculateDiscount(decimal montoSubtotal, DiscountsDTO contextoDescuentos)
        {
            if (!string.IsNullOrWhiteSpace(contextoDescuentos.CodigoCupon) && contextoDescuentos.CodigoCupon.Trim().ToUpperInvariant() == "PROMO10")
            {
                return montoSubtotal * _configuracion.DiscountCode;
            }
            return 0m;
        }

    }
}
