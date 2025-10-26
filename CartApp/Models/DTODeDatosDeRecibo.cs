using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Models
{

    public record DTO_DatosRecibo(
        List<ArticuloDeVenta> Productos,
        decimal Subtotal,
        decimal Descuento,
        decimal Impuesto, 
        decimal Envio, 
        decimal RecargoFragil,
        decimal Total
    );
}