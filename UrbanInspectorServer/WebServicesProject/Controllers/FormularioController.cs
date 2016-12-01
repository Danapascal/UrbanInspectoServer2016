using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using WebServicesProject.DTOs;
using WebServicesProject.Logic;

namespace WebServicesProject.Controllers
{
    [RoutePrefix("api/formulario")]
    public class FormularioController : ApiController
    {
        private readonly FormularioLogic formularioLogic;
        public FormularioController(FormularioLogic formularioLogic)
        {
            if (formularioLogic == null) throw new ArgumentNullException("FormularioLogic no puede ser nulo");

            this.formularioLogic = formularioLogic;
        }

        /// <summary>
        /// Devuelve todas las tareas 
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("get"), Route("preguntas")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string TodasLasTareas()
        {
            List<PreguntaDto> preguntas = new List<PreguntaDto>();
            preguntas = formularioLogic.ObtenerPreguntas();
            return new JavaScriptSerializer().Serialize(preguntas);
        }

        ///// <summary>
        ///// Agrega una nueva tarea
        ///// </summary>
        ///// <param name="creationDto"></param>
        ///// <returns></returns>
        //[AcceptVerbs("post"), Route("nueva")]
        //public long AgregarTodo([FromBody] ToDoCreationDto creationDto)
        //{
        //    return todoLogic.CrearToDo(creationDto);
        //}

        /// <summary>
        /// Agrega un formulario nuevo
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("post"), Route("nuevo")]
        public long EnviarFormulario([FromBody] FormularioRespondidoDto formularioRespondidoDto)
        {
            return formularioLogic.NuevoFormularioRespondido(formularioRespondidoDto);
            
        }
    }
}
