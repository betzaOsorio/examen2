using CartApp.Core.Calcs.Interfaces;
using CartApp.Settings.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Calcs
{
    public class CalculadorIVA : ICalculadorIVA
    {
        private readonly IConfigsDTO _configuracion;
        public CalculadorIVA(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }
        public decimal Calcular(decimal subtotalConDescuento)
        {
            return Math.Round(subtotalConDescuento * _configuracion.TasaIVA, 2, MidpointRounding.AwayFromZero);
        }
    }
}
