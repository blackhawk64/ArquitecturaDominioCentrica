﻿using Dominio.Interfaces;
using Dominio.Modelos;
using Newtonsoft.Json;

namespace Infraestructura.Repositorios
{
    public class RepositorioTareas : IRepositorioTareas
    {
        private readonly ILog logger;

        public RepositorioTareas(ILog logger)
        {
            this.logger = logger;
        }
        public async Task<List<Tarea>> ObtenerTareas()
        {
            var client  = new HttpClient();
            var urlTareas = "https://jsonplaceholder.typicode.com/todos";
            var respuestaTareas = await client.GetAsync(urlTareas);

            respuestaTareas.EnsureSuccessStatusCode();

            var cuerpoRespuestaTareas = await respuestaTareas.Content.ReadAsStringAsync();
            logger.Log(cuerpoRespuestaTareas);

            var tareas = JsonConvert.DeserializeObject<List<Tarea>>(cuerpoRespuestaTareas);
            return tareas;
        }
    }
}
