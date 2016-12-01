using System.Collections.Generic;
using System.Linq;
using NHibernate;
using WebServicesProject.DTOs;
using WebServicesProject.Models;

namespace WebServicesProject.Logic
{
    public class ProductoLogic : BaseLogic
    {
        public ProductoLogic(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
        }

        public List<ProductoDto> ListaProductos()
        {
            var todos = Session.QueryOver<Producto>().List();

            return todos.Select(x =>
                new ProductoDto()
                {
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    PrecioUnitario = x.PrecioUnitario,
                    Utilidad = x.Utilidad                    
                }).ToList();
        }

        //public long CrearToDo(ToDoCreationDto creationDto)
        //{
        //    var prioridad = Session.Get<Prioridad>(creationDto.PrioridadId);
        //    var usuario = Session.Get<Usuario>(creationDto.UsuarioId);

        //    var nuevoToDo = new ToDoEntry()
        //    {
        //        Descripcion = creationDto.Descripcion,
        //        Prioridad = prioridad,
        //        Titulo = creationDto.Titulo,
        //        Usuario = usuario
        //    };

        //    Session.Save(nuevoToDo);

        //    return nuevoToDo.Id;
        //}
    }
}