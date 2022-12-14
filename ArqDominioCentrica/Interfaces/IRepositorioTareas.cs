using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface IRepositorioTareas
    {
        Task<List<Tarea>> ObtenerTareas();
    }
}
