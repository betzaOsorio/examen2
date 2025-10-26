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
    public class ReglaDescuentoVIP : IReglaDescuento
    {
        private readonly IConfigsDTO _configuracion;
        public ReglaDescuentoVIP(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }
        public decimal CalcularDescuento(decimal montoSubtotal, DTO_Descuentos contextoDescuentos)

        {
            if (contextoDescuentos.EsVip)
            {
                return montoSubtotal * _configuracion.TasaDescuentoExtraVIP;
            }
            return 0m;
        }
    }
}
