using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjerciciosORM.Models
{
    [Table("Empleados")]
    public class Empleados
    {
        [Key]
        [Column("EmpleadoID")]
        public int EmpleadoID { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Pais")]
        public string Pais { get; set; }

        [Column("FechaNac")]
        public DateTime FechaNac { get; set; }
    }
}

