namespace tp7
{
    // Define la enumeración Estado antes de la clase Tarea
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; } 
    }
}