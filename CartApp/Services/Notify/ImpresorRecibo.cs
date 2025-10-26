using CartApp.Models;
using CartApp.Services.Notify.interfaces;
using CartApp.Settings;

namespace CartApp.Services.Notify
{
    public class ImpresorRecibo : IImpresorRecibo
    {
        public void Print(string textoRecibo) 
        {
            Console.WriteLine("\n========== Factura ==========");
            Console.WriteLine(textoRecibo);
            Console.WriteLine("==============================\n");
        }
    }
}
