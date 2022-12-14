using Dominio.Interfaces;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class RepositorioResultadoTareasViewModel : IRepositorioResultadoTareasViewModel
    {
        public void Guardar(List<TareaViewModel> tareas)
        {
            using (StreamWriter writeText = new StreamWriter($@"{Directory.GetCurrentDirectory}\tareasPendientes.txt", append: true))
            {
                foreach (var tarea in tareas)
                {
                    writeText.WriteLine($"{DateTime.Now.ToString().PadRight(25)}{tarea.Id.ToString().PadRight(10)}{tarea.NombreUsuario.PadRight(30)}{tarea.Title.PadRight(20)}");
                }
            }
        }
    }
}
