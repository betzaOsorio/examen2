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


            List<Item> listaProductos = new List<Item>
            {
                new Item("Taza", 100m, false),
                new Item("Plato", 60m, false),
                new Item("Florero", 50m, true)
            };

            Console.Write("Ayolaaa Ingrese cupón porfis(PROMO10 o ninguno): ");
            string? codigoCupon = Console.ReadLine(); 

            Console.Write("¿Cliente VIP? (s/n): ");
            bool esVip = Console.ReadLine()?.Trim().ToLower() == "s"; 

            Console.Write("¿Enviar factura por email? (s/n): ");
            bool enviarEmail = Console.ReadLine()?.Trim().ToLower() == "s";

            CartPriceCalculator calculadora = new CartPriceCalculator(); 
            decimal totalCalculado = calculadora.CalculateTotal(listaProductos, codigoCupon, esVip, enviarEmail);

            Console.WriteLine($"Total calculado: Q{totalCalculado:F2}");
            Console.WriteLine("Gracias por su compra queridisisisismo cliente espero vuelva a gastar dinero con nosotros ;) !!!");
        }
    }
}