using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using follow.View.EducadoresView;

namespace follow.Infrastructure
{
     public class AccesoDatosGrupo
    {

        public static int IngresarGrupo(string Nombre, string Materia, string Cod_Materia)
        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insGrupo");

            comando.Parameters.AddWithValue("@Codigo", Cod_Materia);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Materia", Materia);
            

            return MetodoDatos.EjecutarComando(comando);
        }


       public static List<Grupo> ObtenerGrupos()
        {
            List<Grupo> listaGrupo = new List<Grupo>();
            string sql = "select Nombre from grupo";

            using (SqlConnection con = new SqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Grupo grupo = new Grupo()
                            {
                                Nombre = reader.GetString(0),

                            };

                            listaGrupo.Add(grupo);
                        }
                    }
                }

                con.Close();

                return listaGrupo;
            }



        }
    }
}


    