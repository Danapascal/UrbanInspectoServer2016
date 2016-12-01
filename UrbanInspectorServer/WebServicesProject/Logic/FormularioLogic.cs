using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using WebServicesProject.DTOs;
using WebServicesProject.Models;

namespace WebServicesProject.Logic
{
    public class FormularioLogic : BaseLogic
    {
        public FormularioLogic(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
        }

        public List<PreguntaDto> ObtenerPreguntas()
        {
            var preguntas = Session.QueryOver<Pregunta>().Where(p => p.Formulario.FormularioId == 0 ).List();

            return preguntas.Select(x =>
                new PreguntaDto
                {
                    PreguntaId = x.PreguntaId,
                    FormularioId = x.Formulario.FormularioId,
                    Texto = x.Texto,
                    TipoId = x.Tipo.TipoId,
                    PosiblesRespuestas = x.PosibleRespuesta.Select(y =>
                       new PosibleRespuestaDto
                       {
                           PosibleRespuestaId = y.PosibleRespuestaId,
                           PreguntaId = y.PreguntaId,
                           Texto = y.Texto
                        }
                        ).ToList()
                }).ToList();
        }

        public long NuevoFormularioRespondido(FormularioRespondidoDto formularioRespondidoDto)
        {
            var formularioRespondido = new FormularioRespondido()
            {
                FormularioId = formularioRespondidoDto.FormularioId,
                UsuarioId = formularioRespondidoDto.UsuarioId,
                FechaRespondido = formularioRespondidoDto.FechaRespondido,
                Latitud = formularioRespondidoDto.Latitud,
                Longitud = formularioRespondidoDto.Longitud,
                Respuestas =  formularioRespondidoDto.Respuestas.Select(y =>
                       new Respuesta
                       {
                           PosibleRespuestaId = y.PosibleResputaId,
                           Texto = y.Texto
                       }
                        ).ToList()
            };

            Session.Save(formularioRespondido);
            return formularioRespondido.FormularioRespondidoId;
        }

        /*
        static private String salt = "#uTn+DaCs_2016#";
        private string CrearPasswordHash(String password)
        {
            password += salt;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] passwordHash = sha.ComputeHash(bytes);

            return BitConverter.ToString(passwordHash).Replace("-", "");
        }
         * 
          */
    }
}