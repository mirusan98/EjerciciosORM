using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjerciciosORM.Models
{
    [Table("Categorias")] 
    public class Categorias
    {
        [Key]
        [Column("CategoriaID")]
        public int CategoriaID { get; set; }

        [Column("NombreCategoria")]
        public string NombreCategoria { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        // Relación 1:N
        public List<Productos> Productos { get; set; }
    }
}


