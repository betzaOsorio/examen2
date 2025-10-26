using CartApp.Models;
using CartApp.Services;
using CartApp.Settings;
using CartApp.Core;

namespace CartApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Sistema de Carrito de Compras (Versión mala por el Examen :p) ----");


            List<ArticuloDeVenta> listaProductos = new List<ArticuloDeVenta>
            {
                new ArticuloDeVenta("Taza", 100m, false),
                new ArticuloDeVenta("Plato", 60m, false),
                new ArticuloDeVenta("Florero", 50m, true)
            };

            Console.Write("Ayolaaa Ingrese cupón porfis(PROMO10 o ninguno): ");
            string? codigoCupon = Console.ReadLine(); 

            Console.Write("¿Cliente VIP? (s/n): ");
            bool esVip = Console.ReadLine()?.Trim().ToLower() == "s"; 

            Console.Write("¿Enviar factura por email? (s/n): ");
            bool enviarEmail = Console.ReadLine()?.Trim().ToLower() == "s";

            ServicioCalculoFacturacion calculadora = new ServicioCalculoFacturacion();
            decimal totalCalculado = calculadora.CalcularTotal(listaProductos, codigoCupon, esVip, enviarEmail);

            Console.WriteLine($"Total calculado: Q{totalCalculado:F2}");
            Console.WriteLine("Gracias por su compra queridisisisismo cliente espero vuelva a gastar dinero con nosotros ;) !!!");
        }
    }
}