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
    public class FragileSurchargeCalculator : ISurchargeCalculator
    {
        private readonly IConfigsDTO _configuracion;
        public FragileSurchargeCalculator(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }

        public decimal Calculate(List<Item> productos)
        {
            bool hayAlgunoFragil = productos.Any(producto => producto.IsFragile);
            return hayAlgunoFragil ? _configuracion.FragileSurcharge : 0m;
        }
    }
}
