using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Models
{

    public class DiscountsDTO
    {
        public List<Item> Productos { get; }
        public string? CodigoCupon { get; }
        public bool EsVip { get; }

        public DiscountsDTO(List<Item> productos, string? codigoCupon, bool esVip)
        {
            Productos = productos;
            CodigoCupon = codigoCupon;
            EsVip = esVip;
        }
    }
}
