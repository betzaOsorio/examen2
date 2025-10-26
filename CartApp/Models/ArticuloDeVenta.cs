namespace CartApp.Models
{
    public class ArticuloDeVenta
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool EsFragil { get; set; }

        public ArticuloDeVenta(string name, decimal price, bool fragile)
        {
            Nombre = string.IsNullOrWhiteSpace(name) ? "Saber" : name;
            Precio = price;
            EsFragil = fragile;
        }
    }
}