using CartApp.Core.Calcs.Interfaces;
using CartApp.Settings.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Calcs
{
    public class CalculadorEnvio : ICalculadorEnvio
    {
        private readonly IConfigsDTO _configuracion;

        public CalculadorEnvio(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }
        public decimal Calcular(decimal montoSubtotal)
        {
            return montoSubtotal < _configuracion.UmbralEnvio
                       ? _configuracion.EnvioPorDebajoDe
                       : _configuracion.EnvioPorEncimaDeOIgual;
        }

    }
}