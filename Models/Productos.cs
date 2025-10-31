using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjerciciosORM.Models
{
    [Table("Productos")]
    public class Productos
    {
        [Key]
        [Column("ProductoID")]
        public int ProductoID { get; set; }

        [Column("NombreProducto")]
        public string NombreProducto { get; set; }

        [Column("CategoriaID")]
        public int CategoriaID { get; set; }

        [Column("Precio")]
        public decimal Precio { get; set; }

        [ForeignKey("CategoriaID")]
        public Categorias Categoria { get; set; }
    }
}
