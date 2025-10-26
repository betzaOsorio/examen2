using CartApp.Core.Discounts.Interfaces;
using CartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Discounts
{
    public class CalculadorDescuento : ICalculadorDescuento
    {
        private readonly IEnumerable<IDiscountRule> _reglasDescuento;
        public CalculadorDescuento(IEnumerable<IDiscountRule> reglasDescuento)
        {
            _reglasDescuento = reglasDescuento;
        }
        public decimal Calcular(decimal montoSubtotal, DTO_Descuentos contextoDescuentos)
        {
            decimal descuentoTotal = 0m;
            foreach (var regla in _reglasDescuento)
            {
                descuentoTotal += regla.CalcularDescuento(montoSubtotal, contextoDescuentos);
            }
            return descuentoTotal;
        }
    }
}
