using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using follow.View.TutoresView;

namespace follow.Infrastructure
{
   public class AccesoDatosTutor
    {
        public static List<Hijos> ObtenerHijo()
        {
            List<Hijos> listaHijos = new List<Hijos>();
            string sql = "select Materia.Nombre from Materia";

            using (SqlConnection con = new SqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hijos hijo = new Hijos()
                            {
                                Nombre = reader.GetString(0),

                            };

                            listaHijos.Add(hijo);
                        }
                    }
                }

                con.Close();

                return listaHijos;
            }
        }

    }
}
