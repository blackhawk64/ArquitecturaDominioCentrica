using Dominio.Interfaces;

namespace Infraestructura.Loggers
{
    public class LoggerArchivoDeTexto : ILog
    {
        public void Log(string mensaje)
        {
            using (StreamWriter writeText = new StreamWriter(@"C:\log.txt", append: true))
            {
                writeText.WriteLine(mensaje);
            }
        }

        public void LogException(Exception ex)
        {
            string error = $"{ex.Message}: {ex.StackTrace}";
            Log(error);
        }
    }
}
