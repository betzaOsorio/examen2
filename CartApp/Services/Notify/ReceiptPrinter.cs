using CartApp.Models;
using CartApp.Services.Notify.interfaces;
using CartApp.Settings;

namespace CartApp.Services.Notify
{
    public class ReceiptPrinter : IReceiptPrinter
    {
        public void Print(string textoRecibo) 
        {
            Console.WriteLine("\n========== Factura ==========");
            Console.WriteLine(textoRecibo);
            Console.WriteLine("==============================\n");
        }
    }
}
