using MVCEFHaciendaCañaveral.Models;
using MVCEFHaciendaCañaveral.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCEFHaciendaCañaveral.Business
{
    public class UsuarioBusiness
    {
        public List<Usuario> GetAllUsers()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Usuario.Include("Role").ToList();
            }
        }

        public Usuario UserByID(int idUsuario)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Usuario.Include("Role").Single(u => u.IdUsuario == idUsuario);
            }
        }

        public void Editar(Usuario usuario)
        {
            /*
            SqlCommand cmdVenta = new SqlCommand();
            cmdVenta.CommandText = "modificarUsuario";
            cmdVenta.CommandType = System.Data.CommandType.StoredProcedure;
            cmdVenta.Parameters.Add(new SqlParameter("@IdUsuario", usuario.IdUsuario));
            cmdVenta.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
            cmdVenta.Parameters.Add(new SqlParameter("@Apellidos", usuario.Apellidos));
            cmdVenta.Parameters.Add(new SqlParameter("@Email", usuario.Email));
            cmdVenta.Parameters.Add(new SqlParameter("@Password", HashHelper.MD5(usuario.Password)));
            cmdVenta.Parameters.Add(new SqlParameter("@Enable", usuario.Enable));
            cmdVenta.Parameters.Add(new SqlParameter("@IdRole", usuario.Role.IdRole));


            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaciendaCañaVeral"].ConnectionString);
            try
            {
                connection.Open();
                cmdVenta.Connection = connection;
                cmdVenta.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            */
            usuario.Password = HashHelper.MD5(usuario.Password);
            using (var db = new HaciendaCañaveralContext())
            {
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Crear(Usuario usuario)
        {
            /*SqlCommand cmdVenta = new SqlCommand();
            cmdVenta.CommandText = "insertarUsuario";
            cmdVenta.CommandType = System.Data.CommandType.StoredProcedure;
            cmdVenta.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
            cmdVenta.Parameters.Add(new SqlParameter("@Apellidos", usuario.Apellidos));
            cmdVenta.Parameters.Add(new SqlParameter("@Email", usuario.Email));
            cmdVenta.Parameters.Add(new SqlParameter("@Password", HashHelper.MD5(usuario.Password)));
            cmdVenta.Parameters.Add(new SqlParameter("@Enable", usuario.Enable));
            cmdVenta.Parameters.Add(new SqlParameter("@IdRole", usuario.Role.IdRole));


            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaciendaCañaVeral"].ConnectionString);
            try
            {
                connection.Open();
                cmdVenta.Connection = connection;
                cmdVenta.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }*/
            //String password = usuario.Password;
            usuario.Password = HashHelper.MD5(usuario.Password);
            using(var db = new HaciendaCañaveralContext())
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
            }

        }

        public void Eliminar(int idUsuario)
        {
            using (var db = new HaciendaCañaveralContext())
            {
                Usuario usuario = db.Usuario.Find(idUsuario);
                db.Usuario.Remove(usuario);
                db.SaveChanges();
            }
        }
    }
}