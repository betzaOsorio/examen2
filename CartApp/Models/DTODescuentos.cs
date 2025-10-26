using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Models
{

    public class DTO_Descuentos
    {
        public List<ArticuloDeVenta> Productos { get; }
        public string? CodigoCupon { get; }
        public bool EsVip { get; }

        public DTO_Descuentos(List<ArticuloDeVenta> productos, string? codigoCupon, bool esVip)
        {
            Productos = productos;
            CodigoCupon = codigoCupon;
            EsVip = esVip;
        }
    }
}
