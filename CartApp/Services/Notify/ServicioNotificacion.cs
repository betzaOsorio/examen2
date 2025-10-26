using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CartApp.Models;
using CartApp.Services.Notify.interfaces;
using CartApp.Settings.interfaces;

namespace CartApp.Services.Notify
{
    public class ServicioNotificacion : IServicioNotificacion
    {
        private readonly IEmailSender _enviadorEmail; 
        private readonly IReceiptPrinter _impresor; 
        private readonly IReceiptFormatter _formateador; 
        private readonly IConfigsDTO _configuracion; 

        public ServicioNotificacion(
            IEmailSender enviadorEmail,
            IReceiptPrinter impresor,
            IReceiptFormatter formateador,
            IConfigsDTO configuracion)
        {
            _enviadorEmail = enviadorEmail;
            _impresor = impresor;
            _formateador = formateador;
            _configuracion = configuracion;
        }

        public void SendEmailReceipt(DatosReciboDTO datosRecibo)
        {
            string cuerpoEmail = _formateador.Format(datosRecibo);
            _enviadorEmail.Send(_configuracion.EmailReciboPara, _configuracion.EmailReciboAsunto, cuerpoEmail);
        }

        public void PrintConsoleReceipt(DatosReciboDTO datosRecibo)
        {
            string cuerpoRecibo = _formateador.Format(datosRecibo);
            _impresor.Print(cuerpoRecibo);
        }
    }
}