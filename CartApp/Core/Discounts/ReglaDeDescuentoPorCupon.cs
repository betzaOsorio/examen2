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
    public class ReglaDescuentoCupon : IReglaDescuento
    {
        private readonly IConfigsDTO _configuracion;
        public ReglaDescuentoCupon(IConfigsDTO configuracion)
        {
            _configuracion = configuracion;
        }

        public decimal CalcularDescuento(decimal montoSubtotal, DTO_Descuentos contextoDescuentos)
        {
            if (!string.IsNullOrWhiteSpace(contextoDescuentos.CodigoCupon) && contextoDescuentos.CodigoCupon.Trim().ToUpperInvariant() == "PROMO10")
            {
                return montoSubtotal * _configuracion.CodigoDescuento;
            }
            return 0m;
        }

    }
}
