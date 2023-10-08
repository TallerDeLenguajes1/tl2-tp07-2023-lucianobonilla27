    using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace tp7;

public class AccesoADatos
    {
        private List<Tarea> Tareas ;

        public AccesoADatos(){
            Tareas = new();
        }

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


    /* Equivalente CSV 
    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

public class AccesoADatos
{
    private string rutaArchivoCsv = "Models/tareas.csv";

    public AccesoADatos()
    {
    }

    public List<Tarea> Obtener()
    {
        try
        {
            using (var reader = new StreamReader(rutaArchivoCsv))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var tareas = csv.GetRecords<Tarea>().ToList();
                return tareas;
            }
        }
        catch (Exception)
        {
            return new List<Tarea>();
        }
    }

    public void Guardar(List<Tarea> tareas)
    {
        try
        {
            using (var writer = new StreamWriter(rutaArchivoCsv))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(tareas);
            }
        }
        catch (Exception)
        {
            // Manejar cualquier error de escritura de archivo aquí
        }
    }
}
*/
