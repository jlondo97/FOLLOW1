using System;
using System.Collections.Generic;
using System.Text;
using follow.View.EducadoresView;
using System.Data.SqlClient;

namespace follow.Infrastructure
{
   public class AccesoDatosTarea
    {
        public static int IngresarTarea(string Nombre, string Descripcion , string Fecha_inicio, string Fecha_final, string Grupo)

        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insTarea");

            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            comando.Parameters.AddWithValue("@Fecha_final", Fecha_final);
            comando.Parameters.AddWithValue("@grupo", Grupo);

            return MetodoDatos.EjecutarComando(comando);
        }

        public static List<Tarea> ObtenerTareas(String grupo)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            string sql = "select NombreTarea from Tarea where CodGrupo='" + grupo + "'";

            using (SqlConnection con = new SqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tarea tarea = new Tarea()
                            {
                                Nombre = reader.GetString(0),

                            };

                            listaTareas.Add(tarea);
                        }
                    }
                }

                con.Close();

                return listaTareas;
            }



        }
    }
}
