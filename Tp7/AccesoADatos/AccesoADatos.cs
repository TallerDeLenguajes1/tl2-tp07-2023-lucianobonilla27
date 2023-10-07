using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace tp7;

public class AccesoADatos
    {
        private List<Tarea> Tareas = new List<Tarea>();

        public List<Tarea> Obtener(){
            string jsonTareas = File.ReadAllText("Models/tareas.json");
            var tareas = JsonSerializer.Deserialize<Tarea[]>(jsonTareas);
            Tareas.AddRange(tareas);
            return Tareas;
        }

        public void Guardar(List<Tarea> tareas)
        {
            
                // Ruta del archivo JSON donde se guardarán los tareas
                string rutaArchivoJson = "Models/tareas.json";
                var opcionesDeSerializacion = new JsonSerializerOptions
                    {
                        WriteIndented = true // Esto activa la indentación
                    };
                // Serializar la lista de tareas a formato JSON
                string jsonTareas = JsonSerializer.Serialize(tareas,opcionesDeSerializacion);

                // Escribir el JSON en el archivo
                File.WriteAllText(rutaArchivoJson, jsonTareas);
            
           
        }
    }