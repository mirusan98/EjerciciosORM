namespace EjerciciosORM.Models
{
    public class Empleados
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Titulo { get; set; }
        public string Pais { get; set; }
        public DateTime FechaNac { get; set; }

        // Propiedad calculada (opcional)
        public string FullName => $"{Nombre} {Apellido}";
    }
}
