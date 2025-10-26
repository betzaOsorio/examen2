using CartApp.Core.Calcs.Interfaces;
using CartApp.Settings.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Calcs
{
    public class IVACalculator : IIVACalculator
    {
        private readonly IConfigsDTO _configuracion;
        public IVACalculator(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }
        public decimal Calculate(decimal subtotalConDescuento)
        {
            return Math.Round(subtotalConDescuento * _configuracion.IVARate, 2, MidpointRounding.AwayFromZero);
        }
    }
}
