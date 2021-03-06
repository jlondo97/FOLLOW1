﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using follow.View.EducadoresView;

namespace follow.Infrastructure
{
     public class AccesoDatosGrupo
    {

        public static int IngresarGrupo(string Nombre, string Materia, string Cod_Materia, string Estudiante)
        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insGrupo");

            comando.Parameters.AddWithValue("@CodEnlace", Cod_Materia);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Materia", Materia);
            comando.Parameters.AddWithValue("@Estudiante", Estudiante);


            return MetodoDatos.EjecutarComando(comando);
        }

        public static int IngresarEstudiante(string Cod_Materia, string Nombre, string Estudiante)
        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insEstGrupo");

            comando.Parameters.AddWithValue("@CodEnlace", Cod_Materia);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Estudiante", Estudiante);


            return MetodoDatos.EjecutarComando(comando);
        }



        public static List<Grupo> ObtenerGrupos(string materi)
        {
            List<Grupo> listaGrupo = new List<Grupo>();
            string sql = "select Nombre from grupo where Materia='" + materi + "'";

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

        public static List<Grupo> ObtenerCodigo(string nombre)
        {
            List<Grupo> listacodigo = new List<Grupo>();
            string sql = "select CodEnlace from grupo where Nombre ='" + nombre + "'";

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
                                CodEnlace= reader.GetString(0),

                            };

                            listacodigo.Add(grupo);
                        }
                    }
                }

                con.Close();

                return listacodigo;
            }



        }

        public static DataTable VerificarGrupo(string Grupo)
        {
            SqlCommand Comando = MetodoDatos.CrearComando();
            Comando.CommandText = "select Nombre from grupo where CodEnlace='" + Grupo + "'";
            return MetodoDatos.EjecutarSelect(Comando);
        }

        public static List<Grupo> ObtenerGruposEst(string correo)
        {
            List<Grupo> listaGrupo = new List<Grupo>();
            string sql = "select Nombre from grupo where Estudiante='" + correo + "'";

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

        public static List<Grupo> ObtenerEstudiantes(string grup)
        {
            List<Grupo> listaGrupo = new List<Grupo>();
            string sql = "select Estudiante from grupo where Nombre='" + grup + "' and Estudiante <>''";

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
                               Estudiante = reader.GetString(0),

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


    