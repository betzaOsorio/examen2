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
    public class NotificationService : INotificationService
    {
        private readonly IEmailSender _enviadorEmail; 
        private readonly IReceiptPrinter _impresor; 
        private readonly IReceiptFormatter _formateador; 
        private readonly IConfigsDTO _configuracion; 

        public NotificationService(
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

        public void SendEmailReceipt(ReceiptsDataDTO datosRecibo)
        {
            string cuerpoEmail = _formateador.Format(datosRecibo);
            _enviadorEmail.Send(_configuracion.ReceiptEmailTo, _configuracion.ReceiptEmailSubject, cuerpoEmail);
        }

        public void PrintConsoleReceipt(ReceiptsDataDTO datosRecibo)
        {
            string cuerpoRecibo = _formateador.Format(datosRecibo);
            _impresor.Print(cuerpoRecibo);
        }
    }
}