using CartApp.Core.Calcs.Interfaces;
using CartApp.Models;
using CartApp.Settings.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Calcs
{
    public class CalculadorRecargoFragil : ICalculadorRecargoFragil
    {
        private readonly IConfigsDTO _configuracion;
        public CalculadorRecargoFragil(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }

        public decimal Calcular(List<ArticuloDeVenta> productos)
        {
            bool hayAlgunoFragil = productos.Any(producto => producto.EsFragil);
            return hayAlgunoFragil ? _configuracion.RecargoFragil : 0m;
        }
    }
}
