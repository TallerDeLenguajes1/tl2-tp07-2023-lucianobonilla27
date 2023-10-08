using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp7;

namespace Tp7.Models
{
    public class ManejoDeTareas
    {
        private int autonumerico;
        private AccesoADatos accesoADatos;
        private List<Tarea> listaTareas;

        public ManejoDeTareas(){
            accesoADatos = new AccesoADatos();
            listaTareas = accesoADatos.Obtener();
            int mayor=0;
            if (listaTareas != null)
            {
                foreach (var tarea in listaTareas)
                {
                    if (tarea.Id > mayor)
                    {
                        mayor = tarea.Id;
                    }
                }
                autonumerico = mayor;
            }else
            {
                autonumerico = 0;
            }
        }
        public bool CrearTarea(Tarea nueva)
        {
            try
            {
                autonumerico++;
                nueva.Id = autonumerico;
                listaTareas.Add(nueva);
                accesoADatos.Guardar(listaTareas);
                return true; // Indica que la tarea se creó exitosamente
            }
            catch (Exception)
            {
                return false; // Indica que hubo un error al crear la tarea
            }
        }

        public Tarea ObtenerTarea(int id){
            Tarea tareaBuscada = listaTareas.FirstOrDefault(tarea => tarea.Id == id);
            return tareaBuscada;
        }

        public bool ActualizarTarea(Tarea tareaActualizada)
        {
            Tarea tareaExistente = listaTareas.FirstOrDefault(t => t.Id == tareaActualizada.Id);
            if (tareaExistente != null)
            {
                tareaExistente.Titulo = tareaActualizada.Titulo;
                tareaExistente.Descripcion = tareaActualizada.Descripcion;
                tareaExistente.Estado = tareaActualizada.Estado;
                accesoADatos.Guardar(listaTareas);
                return true;
            }else
            {
                return false;
            }
        }
        public bool EliminarTarea(int id){
            Tarea tareaExistente = listaTareas.FirstOrDefault(t => t.Id == id);
            if (tareaExistente != null)
            {
                listaTareas.Remove(tareaExistente);
                accesoADatos.Guardar(listaTareas);
                return true;
            }else
            {
                return false;
            }
                
        }

        public List<Tarea> GetTareas(){
            return listaTareas;
        }

        public List<Tarea> GetTareasCompletadas(){
            List<Tarea> completadas = new();
            foreach (var tarea in listaTareas)
            {
                if (tarea.Estado == "Completada")
                {
                    completadas.Add(tarea);
                }
            }
            return completadas;
        }

        
    }
}