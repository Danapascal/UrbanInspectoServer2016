using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using WebServicesProject.DTOs;
using WebServicesProject.Models;

namespace WebServicesProject.Logic
{
    public class UsuarioLogic : BaseLogic
    {
        public UsuarioLogic(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
        }

        public List<UsuarioDto> ObtenerTodos()
        {
            var usuarios = Session.QueryOver<Usuario>().List();

            return usuarios.Select(x =>
                new UsuarioDto
                {
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Login = x.Login,
                    UsuarioId = x.UsuarioId,
                    Password = x.Password,
                    UltimoLogin = x.UltimoLogin
                }).ToList();
        }

        /*public long CrearNuevo(UsuarioCreationDto creationDto)
        {
            var usuario = new Usuario()
            {
                Nombre = creationDto.Nombre,
                Email = creationDto.Email,
                PasswordHash = CrearPasswordHash(creationDto.Password)
            };

            Session.Save(usuario);
            return usuario.Id;
        }

        static private String salt = "#uTn+DaCs_2016#";
        private string CrearPasswordHash(String password)
        {
            password += salt;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] passwordHash = sha.ComputeHash(bytes);

            return BitConverter.ToString(passwordHash).Replace("-", "");
        }*/
    }
}