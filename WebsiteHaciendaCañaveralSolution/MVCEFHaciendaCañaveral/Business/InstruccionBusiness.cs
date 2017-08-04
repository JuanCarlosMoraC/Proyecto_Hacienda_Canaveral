using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCEFHaciendaCañaveral.Business
{
    public class InstruccionBusiness
    {

        public List<Instruccion> GetAllInstrucciones()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Instruccion.ToList();
            }
        }

        internal Boolean Create(Instruccion instruccion, HttpPostedFileBase file, String ruta)
        {
            SqlCommand cmdInstruccion = new SqlCommand();
            cmdInstruccion.CommandText = "insertarInstruccion";
            cmdInstruccion.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInstruccion.Parameters.Add(new SqlParameter("@Descripcion", instruccion.Descripcion));
            cmdInstruccion.Parameters.Add(new SqlParameter("@IdReceta", instruccion.IdReceta));

            SqlParameter parametroIdInstruccion = new SqlParameter("@IdInstruccion", System.Data.SqlDbType.Int);
            parametroIdInstruccion.Direction = System.Data.ParameterDirection.Output;

            cmdInstruccion.Parameters.Add(parametroIdInstruccion);

            SqlCommand cmdUrlInstruccion = new SqlCommand();
            cmdUrlInstruccion.CommandText = "insertarUrlInstruccion";
            cmdUrlInstruccion.CommandType = System.Data.CommandType.StoredProcedure;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaciendaCañaVeral"].ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                if (Utilidades.Formato(file.FileName) != null)
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    cmdUrlInstruccion.Connection = connection;
                    cmdUrlInstruccion.Transaction = transaction;
                    cmdInstruccion.Connection = connection;
                    cmdInstruccion.Transaction = transaction;

                    cmdInstruccion.ExecuteNonQuery();
                    instruccion.IdInstruccion = Int32.Parse(cmdInstruccion.Parameters["@IdInstruccion"].Value.ToString());

                    instruccion.UrlImagen = Utilidades.GetUriImage(instruccion.IdInstruccion, Utilidades.Formato(file.FileName),false);

                    cmdUrlInstruccion.Parameters.Add(new SqlParameter("@Url", instruccion.UrlImagen));
                    cmdUrlInstruccion.Parameters.Add(new SqlParameter("@IdInstruccion", instruccion.IdInstruccion));
                    cmdUrlInstruccion.ExecuteNonQuery();

                    ruta += instruccion.UrlImagen;
                    file.SaveAs(ruta);

                    transaction.Commit();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}