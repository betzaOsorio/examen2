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
    public class VipDiscountRule : IDiscountRule
    {
        private readonly IConfigsDTO _configuracion;
        public VipDiscountRule(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }
        public decimal CalculateDiscount(decimal montoSubtotal, DiscountsDTO contextoDescuentos)

        {
            if (contextoDescuentos.EsVip)
            {
                return montoSubtotal * _configuracion.VipExtraDiscountRate;
            }
            return 0m;
        }
    }
}
