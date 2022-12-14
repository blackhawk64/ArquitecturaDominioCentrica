using Dominio.Interfaces;

namespace Infraestructura.Loggers
{
    public class LoggerConsola : ILog
    {
        public void Log(string mensaje)
        {
            Console.WriteLine($"{DateTime.Now}: {mensaje}");
        }

        public void LogException(Exception ex)
        {
            SetearColor(ConsoleColor.Red);
            string error = $"{ex.Message}: {ex.StackTrace}";
            Log(error);
            SetearColor(ConsoleColor.White);
        }

        public void SetearColor(ConsoleColor color)
        {
            Console.ForegroundColor= color;
        }
    }
}
