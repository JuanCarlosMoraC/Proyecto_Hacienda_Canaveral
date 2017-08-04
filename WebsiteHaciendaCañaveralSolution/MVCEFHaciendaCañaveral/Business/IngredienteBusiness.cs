using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCEFHaciendaCañaveral.Business
{
    public class IngredienteBusiness
    {
        public List<Ingrediente> GetAllIngredientes()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Ingrediente.ToList();
            }
        }

        internal Boolean Create(Ingrediente ingrediente, HttpPostedFileBase file, String ruta)
        {
            /*using (var db = new HaciendaCañaveralContext())
            {
                db.Ingrediente.Add(ingrediente);
                db.SaveChanges();
            }
            file.SaveAs(ruta);
            */

            SqlCommand cmdIngrediente = new SqlCommand();
            cmdIngrediente.CommandText = "insertarIngrediente";
            cmdIngrediente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdIngrediente.Parameters.Add(new SqlParameter("@Nombre", ingrediente.Nombre));
            cmdIngrediente.Parameters.Add(new SqlParameter("@IdReceta", ingrediente.IdReceta));

            SqlParameter parametroIdIngrediente = new SqlParameter("@IdIngrediente", System.Data.SqlDbType.Int);
            parametroIdIngrediente.Direction = System.Data.ParameterDirection.Output;

            cmdIngrediente.Parameters.Add(parametroIdIngrediente);

            SqlCommand cmdUrlIngrediente = new SqlCommand();
            cmdUrlIngrediente.CommandText = "insertarUrlIngrediente";
            cmdUrlIngrediente.CommandType = System.Data.CommandType.StoredProcedure;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["HaciendaCañaVeral"].ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                if (Utilidades.Formato(file.FileName) != null)
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    cmdUrlIngrediente.Connection = connection;
                    cmdUrlIngrediente.Transaction = transaction;
                    cmdIngrediente.Connection = connection;
                    cmdIngrediente.Transaction = transaction;

                    cmdIngrediente.ExecuteNonQuery();
                    ingrediente.IdIngrediente = Int32.Parse(cmdIngrediente.Parameters["@IdIngrediente"].Value.ToString());

                    ingrediente.UrlImagen = Utilidades.GetUriImage(ingrediente.IdIngrediente, Utilidades.Formato(file.FileName),true);

                    cmdUrlIngrediente.Parameters.Add(new SqlParameter("@Url", ingrediente.UrlImagen));
                    cmdUrlIngrediente.Parameters.Add(new SqlParameter("@IdIngrediente", ingrediente.IdIngrediente));
                    cmdUrlIngrediente.ExecuteNonQuery();

                    ruta += ingrediente.UrlImagen;
                    file.SaveAs(ruta);

                    transaction.Commit();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                if(transaction!= null)
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