using CartApp.Core.Calcs;
using CartApp.Core.Calcs.Interfaces;
using CartApp.Core.Discounts;
using CartApp.Core.Discounts.Interfaces;

using CartApp.Models;

using CartApp.Services.Loggin;
using CartApp.Services.Notify;
using CartApp.Services.Notify.interfaces;

using CartApp.Settings;

namespace CartApp
{
    public class CartPriceCalculator
    {

        private readonly ILogger _logger;
        private readonly ICartValidator _validador;
        private readonly ISubtotalCalculator _calculadorSubtotal;
        private readonly IDiscountCalculator _calculadorDescuento; 
        private readonly IShippingCalculator _calculadorEnvio; 
        private readonly ISurchargeCalculator _calculadorRecargoFragil;
        private readonly IIVACalculator _calculadorImpuesto;
        private readonly INotificationService _servicioNotificacion;


        public CartPriceCalculator()
        {

            var configuracion = new ConfigsReader(); 


            _logger = new ConsoleLogger();


            _validador = new CartValidator();
            _calculadorSubtotal = new SubtotalCalculator();
            _calculadorEnvio = new ShippingCalculator(configuracion);
            _calculadorRecargoFragil = new FragileSurchargeCalculator(configuracion);
            _calculadorImpuesto = new IVACalculator(configuracion);


            var reglasDescuento = new List<IDiscountRule> 
            {
                new VipDiscountRule(configuracion),
                new CouponDiscountRule(configuracion)

            };
            _calculadorDescuento = new DiscountCalculator(reglasDescuento);


            var enviadorEmail = new EmailSender();
            var impresor = new ReceiptPrinter();
            var formateador = new ReceiptFormatter();

            _servicioNotificacion = new NotificationService(enviadorEmail, impresor, formateador, configuracion);
        }


        public decimal CalculateTotal(List<Item> productos, string? codigoCupon, bool esVip, bool enviarReciboEmail) 
        {
            _logger.Info("Inicio de cálculo de carrito.");


            try
            {
                _validador.Validate(productos);
            }
            catch (ArgumentException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }

            if (productos == null || productos.Count == 0)
            {
                _logger.Info("Carrito vacío: total = 0.");
                return 0m;
            }


            decimal montoSubtotal = _calculadorSubtotal.Calculate(productos); 


            var contextoDescuentos = new DiscountsDTO(productos, codigoCupon, esVip);
            decimal descuento = _calculadorDescuento.Calculate(montoSubtotal, contextoDescuentos); 

            decimal subtotalConDescuento = montoSubtotal - descuento;

            decimal costoEnvio = _calculadorEnvio.Calculate(montoSubtotal);
            decimal recargoFragil = _calculadorRecargoFragil.Calculate(productos);
            decimal impuesto = _calculadorImpuesto.Calculate(subtotalConDescuento);


            decimal total = subtotalConDescuento + costoEnvio + recargoFragil + impuesto;


            var datosRecibo = new ReceiptsDataDTO( 
                productos,
                montoSubtotal,
                descuento,
                impuesto,
                costoEnvio,
                recargoFragil,
                total
            );


            _servicioNotificacion.PrintConsoleReceipt(datosRecibo);


            if (enviarReciboEmail)
            {
                _servicioNotificacion.SendEmailReceipt(datosRecibo);
            }

            _logger.Info($"Fin de cálculo. Total: Q{total:F2}");
            return total;
        }
    }
}