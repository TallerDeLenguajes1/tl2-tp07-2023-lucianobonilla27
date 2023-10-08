namespace tp7
{
    // Define la enumeración Estado antes de la clase Tarea

    public class Tarea
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; } 

        public Tarea(string titulo,string descripcion,string estado){
           
            this.Titulo = titulo;
       
            this.Descripcion = descripcion;
            this.Estado = estado;
        }
         public Tarea()
        {
        }
    }
}