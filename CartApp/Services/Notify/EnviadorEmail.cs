using CartApp.Services.Notify.interfaces;

namespace CartApp.Services.Notify
{
    public class EnviadorEmail : IEnviadorEmail
    {
        public void Send(string emailDestinatario, string asuntoEmail, string cuerpoEmail)
        {
            Console.WriteLine("\n=== Enviando el Email ===");
            Console.WriteLine($"Persona: {emailDestinatario}");
            Console.WriteLine($"Tema: {asuntoEmail}");
            Console.WriteLine("Cuerpo de Email:");
            Console.WriteLine(cuerpoEmail);
            Console.WriteLine("======================\n");
        }
    }
}