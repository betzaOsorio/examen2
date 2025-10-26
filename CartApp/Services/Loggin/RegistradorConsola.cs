namespace CartApp.Services.Loggin
{
    public class RegistradorConsola : IRegistrador
    {
        public void Info(string mensaje)
        {
            Console.WriteLine($"[INFO ] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {mensaje}");
        }

        public void Error(string mensaje)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {mensaje}");
        }
    }
}