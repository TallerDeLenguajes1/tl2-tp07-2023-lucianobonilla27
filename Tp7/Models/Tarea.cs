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
        static int autonumerico = 0;
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; } 

        Tarea(string titulo,string descripcion,string estado){
            autonumerico++;
            this.Id = autonumerico;
            this.Descripcion = descripcion;
            this.Estado = estado;
        }
    }
}