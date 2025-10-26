using CartApp.Core.Calcs.Interfaces;
using CartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Calcs
{
    public class ValidadorCarrito : IValidadorCarrito
    {
        public void Validate(List<ArticuloDeVenta> productos)
        {
            if (productos == null || productos.Count == 0)
            {
                return;
            }
            foreach (var producto in productos)
            {
                if (producto.Precio < 0)
                {
                    throw new ArgumentException($"Negative price for item: {producto.Nombre}");
                }
            }
        }
    }
}
