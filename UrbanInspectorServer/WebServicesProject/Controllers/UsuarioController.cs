using System;
using System.Collections.Generic;
using System.Web.Http;
using WebServicesProject.DTOs;
using WebServicesProject.Logic;

namespace WebServicesProject.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuarioController : ApiController
    {
        private readonly UsuarioLogic usuarioLogic;
        public UsuarioController(UsuarioLogic usuarioLogic)
        {
            if (usuarioLogic == null) throw new ArgumentNullException("UsuarioLogic no puede ser nulo");

            this.usuarioLogic = usuarioLogic;
        }

        /// <summary>
        /// Devuelve todas las tareas 
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("get"), Route("todos")]
        public List<UsuarioDto> TodasLasTareas()
        {
            return usuarioLogic.ObtenerTodos();
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
    }
}
