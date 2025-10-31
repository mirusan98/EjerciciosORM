namespace EjerciciosORM.Models
{
    public class Productos
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public int CategoriaID { get; set; }
        public decimal Precio { get; set; }
        public Categorias? Categoria { get; set; }
        // el ? es para indicar que puede ser nulo
    }
}
