using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp7;

namespace Tp7.Models
{
    public class ManejoDeTareas
    {
        private AccesoADatos accesoADatos = new();
        private List<Tarea> listaTareas = new();

        public ManejoDeTareas(){
            listaTareas = accesoADatos.Obtener();
        }
        public void CrearTarea(Tarea nueva){
            listaTareas = accesoADatos.Obtener();
            listaTareas.Add(nueva);
            accesoADatos.Guardar(listaTareas);
            
        }

        public Tarea ObtenerTarea(int id){
            listaTareas = accesoADatos.Obtener();
            Tarea tareaBuscada = listaTareas.FirstOrDefault(tarea => tarea.Id == id);
            return tareaBuscada;
        }

        public void ActualizarTarea(int id,Tarea nueva){
            listaTareas = accesoADatos.Obtener();
            Tarea tareaBuscada = listaTareas.FirstOrDefault(tarea => tarea.Id == id);
            tareaBuscada = nueva;
            accesoADatos.Guardar(listaTareas);

        }
        public void EliminarTarea(int id){
            listaTareas = accesoADatos.Obtener();
            Tarea tareaBuscada = listaTareas.FirstOrDefault(tarea => tarea.Id == id);
            listaTareas.Remove(tareaBuscada);
            accesoADatos.Guardar(listaTareas);

            
        }

        public List<Tarea> GetTareas(){
            listaTareas = accesoADatos.Obtener();
            return listaTareas;
        }

        public List<Tarea> GetTareasCompletadas(){
            listaTareas = accesoADatos.Obtener();
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