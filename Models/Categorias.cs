namespace EjerciciosORM.Models
{
    public class Categorias
    {
        public int CategoriaID { get; set; }
        public string? NombreCategoria { get; set; }
        public string? Descripcion { get; set; }
        public List<Productos>? Productos { get; set; }
    }
}

