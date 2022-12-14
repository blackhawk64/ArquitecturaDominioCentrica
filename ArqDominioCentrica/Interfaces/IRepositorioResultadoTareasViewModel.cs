using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface IRepositorioResultadoTareasViewModel
    {
        void Guardar(List<TareaViewModel> tareas);
    }
}
