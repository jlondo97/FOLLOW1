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

        public static List<Tarea> ObtenerInfoTarea(String tareabuscar)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            string sql = "select * from Tarea where CodGrupo='" + tareabuscar + "'";

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
                                Descripcion = reader.GetString(1),
                                FechaInicio = reader.GetString(2),
                                FechaFin = reader.GetString(3),
                                CodGrupo = reader.GetString(4),

                            };

                            listaTareas.Add(tarea);
                        }
                    }
                }

                con.Close();

                return listaTareas;
            }



        }

        public static List<Tarea> ObtenerFechaInicio(String tareainfo)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            string sql = "select FechaInicio from Tarea where NombreTarea='" + tareainfo + "'";

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
                                FechaInicio = reader.GetString(0),

                            };

                            listaTareas.Add(tarea);
                        }
                    }
                }

                con.Close();

                return listaTareas;
            }



        }

        public static List<Tarea> ObtenerFechaFin(String tareainfo)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            string sql = "select FechaFinal from Tarea where NombreTarea='" + tareainfo + "'";

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
                                FechaFin = reader.GetString(0),

                            };

                            listaTareas.Add(tarea);
                        }
                    }
                }

                con.Close();

                return listaTareas;
            }



        }

        public static List<Tarea> ObtenerDescripcion(String tareainfo)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            string sql = "select Descripcion from Tarea where NombreTarea='" + tareainfo + "'";

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
                                Descripcion = reader.GetString(0),

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
