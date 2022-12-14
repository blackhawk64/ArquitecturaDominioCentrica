using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ILog
    {
        void Log(string mensaje);
        void LogException(Exception ex);
    }
}
