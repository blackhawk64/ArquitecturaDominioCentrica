using Dominio.Interfaces;
using Dominio.Mapeadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProcesadorDeTareas
    {
        private readonly ILog logger;
        private readonly IRepositorioTareas repositorioTareas;
        private readonly IRepositorioUsuarios repositorioUsuarios;
        private readonly Mapeador mapeador;
        private readonly IRepositorioResultadoTareasViewModel repositorioResultadoTareasViewModel;

        public ProcesadorDeTareas(ILog logger
			,IRepositorioTareas repositorioTareas
			,IRepositorioUsuarios repositorioUsuarios
			,Mapeador mapeador
			,IRepositorioResultadoTareasViewModel repositorioResultadoTareasViewModel)
		{
            this.logger = logger;
            this.repositorioTareas = repositorioTareas;
            this.repositorioUsuarios = repositorioUsuarios;
            this.mapeador = mapeador;
            this.repositorioResultadoTareasViewModel = repositorioResultadoTareasViewModel;
        }

        public async Task Procesar()
        {
			try
			{
				logger.Log("Inicio de Procesamiento");

				var tareas = await repositorioTareas.ObtenerTareas();
				var tareasNoRealidadas = tareas.Where(x => !x.Completed).ToList();
				var usuarios = await repositorioUsuarios.ObtenerUsuarios();

				logger.Log("Inicio de transformación a ViewModels");
				var tareasViewModel = mapeador.Mapear(tareasNoRealidadas, usuarios);

				logger.Log("Inicio de escritura de tareas en archivo");
				repositorioResultadoTareasViewModel.Guardar(tareasViewModel);
			}
			catch (Exception ex)
			{
				logger.LogException(ex);
			}
        }
    }
}
