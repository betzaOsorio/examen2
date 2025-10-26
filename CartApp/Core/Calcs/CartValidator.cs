using CartApp.Core.Calcs.Interfaces;
using CartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Calcs
{
    public class CartValidator : ICartValidator
    {
        public void Validate(List<Item> productos)
        {
            if (productos == null || productos.Count == 0)
            {
                return;
            }
            foreach (var producto in productos)
            {
                if (producto.Price < 0)
                {
                    throw new ArgumentException($"Negative price para item: {producto.Name}");
                }
            }
        }
    }
}
