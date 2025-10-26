using CartApp.Settings.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.Settings
{
    public class LectorConfiguraciones : ILectorConfiguraciones
    {
        public decimal CodigoDescuento => StaticConfig.TasaDescuentoPromo10;
        public decimal TasaDescuentoExtraVIP => StaticConfig.TasaDescuentoExtraVip;
        public decimal UmbralEnvio => StaticConfig.UmbralEnvio;
        public decimal EnvioPorDebajoDe => StaticConfig.CuotaDebajoUmbral;
        public decimal EnvioPorEncimaDeOIgual => StaticConfig.CuotaArribaOIgualUmbral;
        public decimal RecargoFragil => StaticConfig.RecargoFragil;
        public decimal TasaIVA => StaticConfig.TasaIVA;
        public string EmailReciboPara => StaticConfig.EmailDestinatarioRecibo;
        public string EmailReciboAsunto => StaticConfig.AsuntoEmailRecibo;
    }
}