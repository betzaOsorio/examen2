using CartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Core.Discounts.Interfaces
{
    public interface IReglaDescuento
    {
        decimal CalcularDescuento(decimal montoSubtotal, DTO_Descuentos contextoDescuentos);
    }
}