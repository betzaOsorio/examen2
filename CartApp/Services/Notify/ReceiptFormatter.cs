using CartApp.Models;
using CartApp.Services.Notify.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CartApp.Services.Notify
{
    public class ReceiptFormatter : IReceiptFormatter
    {
        public string Format(ReceiptsDataDTO datosRecibo) 
        {
            StringBuilder lineas = new StringBuilder();
            lineas.AppendLine("RECIBO DE COMPRA");
            foreach (Item producto in datosRecibo.Productos) 
            {
                lineas.AppendLine($"- {producto.Name}  Q{producto.Price:F2} {(producto.IsFragile ? "(Frágil)" : "")}");
            }
            lineas.AppendLine($"Subtotal: Q{datosRecibo.Subtotal:F2}");
            lineas.AppendLine($"Descuento: -Q{datosRecibo.Descuento:F2}"); 
            lineas.AppendLine($"IVA: Q{datosRecibo.Impuesto:F2}"); 
            lineas.AppendLine($"Envío: Q{datosRecibo.Envio:F2}"); 
            lineas.AppendLine($"Recargo frágil: Q{datosRecibo.RecargoFragil:F2}"); 
            lineas.AppendLine($"TOTAL: Q{datosRecibo.Total:F2}");
            return lineas.ToString();
        }
    }
}