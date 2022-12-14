using Dominio.Interfaces;

namespace Infraestructura.Factorias
{
    public class FactoriaLoggers
    {
        public ILog ObtenerLogger(string discriminante)
        {
            switch (discriminante)
            {
                case 'consola':
                    return new LoggerConsola();
                case 'archivo':
                    return new LoggerArchivoDeTexto();
                default:
                    break;
            }
        }
    }
}
