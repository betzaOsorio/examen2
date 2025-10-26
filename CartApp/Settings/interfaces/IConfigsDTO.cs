using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Settings.interfaces
{

    public interface IConfigsDTO
    {
        decimal CodigoDescuento { get; }
        decimal TasaDescuentoExtraVIP { get; }
        decimal UmbralEnvio { get; }
        decimal EnvioPorDebajoDe { get; }
        decimal EnvioPorEncimaDeOIgual { get; }
        decimal RecargoFragil { get; }
        decimal TasaIVA { get; }
        string EmailReciboPara { get; }
        string EmailReciboAsunto { get; }
    }
}
