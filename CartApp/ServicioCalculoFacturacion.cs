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
    public class ServicioCalculoFacturacion
    {

        private readonly IRegistrador _logger;
        private readonly IValidadorCarrito _validador;
        private readonly ICalculadorSubtotal _calculadorSubtotal;
        private readonly ICalculadorDescuento _calculadorDescuento; 
        private readonly ICalculadorEnvio _calculadorEnvio; 
        private readonly ICalculadorRecargoFragil _calculadorRecargoFragil;
        private readonly ICalculadorIVA _calculadorImpuesto;
        private readonly IServicioNotificacion _servicioNotificacion;


        public ServicioCalculoFacturacion()
        {

            var configuracion = new LectorConfiguraciones(); 


            _logger = new RegistradorConsola();


            _validador = new ValidadorCarrito();
            _calculadorSubtotal = new CalculadorSubtotal();
            _calculadorEnvio = new CalculadorEnvio(configuracion);
            _calculadorRecargoFragil = new CalculadorRecargoFragil(configuracion);
            _calculadorImpuesto = new CalculadorIVA(configuracion);


            var reglasDescuento = new List<ArticuloDeVenta> 
            {
                new ArticuloDeVenta("Descuento VIP", 0m, false),
                new ArticuloDeVenta("Descuento por Cupón", 0m, false)

            };
            _calculadorDescuento = new CalculadorDescuento(reglasDescuento);


            var enviadorEmail = new EnviadorEmail();
            var impresor = new ImpresorRecibo();
            var formateador = new FormateadorRecibo();

            _servicioNotificacion = new ServicioNotificacion(enviadorEmail, impresor, formateador, configuracion);
        }


        public decimal CalcularTotal(List<ArticuloDeVenta> productos, string? codigoCupon, bool esVip, bool enviarReciboEmail) 
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


            decimal montoSubtotal = _calculadorSubtotal.Calcular(productos);


            var contextoDescuentos = new DiscountsDTO(productos, codigoCupon, esVip);
            decimal descuento = _calculadorDescuento.Calcular(montoSubtotal, contextoDescuentos);

            decimal subtotalConDescuento = montoSubtotal - descuento;

            decimal costoEnvio = _calculadorEnvio.Calcular(montoSubtotal);
            decimal recargoFragil = _calculadorRecargoFragil.Calcular(productos);
            decimal impuesto = _calculadorImpuesto.Calcular(subtotalConDescuento);


            decimal total = subtotalConDescuento + costoEnvio + recargoFragil + impuesto;


            var datosRecibo = new DatosReciboDTO( 
                productos,
                montoSubtotal,
                descuento,
                impuesto,
                costoEnvio,
                recargoFragil,
                total
            );


            _servicioNotificacion.ImprimirReciboConsola(datosRecibo);


            if (enviarReciboEmail)
            {
                _servicioNotificacion.EnviarReciboEmail(datosRecibo);
            }

            _logger.Info($"Fin de cálculo. Total: Q{total:F2}");
            return total;
        }
    }
}