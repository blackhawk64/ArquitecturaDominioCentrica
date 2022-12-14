using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface IRepositorioUsuarios
    {
        Task<List<Usuario>> ObtenerUsuarios();
    }
}
