using CartApp.Core.Calcs.Interfaces;
using CartApp.Settings.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Calcs
{
    public class ShippingCalculator : IShippingCalculator
    {
        private readonly IConfigsDTO _configuracion;

        public ShippingCalculator(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }
        public decimal Calculate(decimal montoSubtotal)
        {
            return montoSubtotal < _configuracion.ShippingThreshold
                       ? _configuracion.ShippingBelowFee
                       : _configuracion.ShippingAboveOrEqualFee;
        }

    }
}