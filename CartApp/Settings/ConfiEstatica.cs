namespace CartApp.Settings
{
    public static class ConfiguracionEstatica
    {
        public static decimal TasaIVA = 0.12m;
        public static decimal UmbralEnvio = 200m;
        public static decimal CuotaDebajoUmbral = 30m; 
        public static decimal CuotaArribaOIgualUmbral = 0m; 
        public static decimal TasaDescuentoPromo10 = 0.10m; 
        public static decimal TasaDescuentoExtraVip = 0.05m; 
        public static decimal RecargoFragil = 15m; 
        public static string EmailDestinatarioRecibo = "clienteBet@example.com"; 
        public static string AsuntoEmailRecibo = "Recibo de compra"; 
    }
}
