﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using follow.View.EducadoresView;

namespace follow.Infrastructure
{
    public class AccesoDatosMateria
    {
        public static int IngresarMateria(string Nombre, string Profe)
        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insMateria");
            comando.Parameters.AddWithValue("@Nom", Nombre);
            comando.Parameters.AddWithValue("@Profe", Profe);
            

            return MetodoDatos.EjecutarComando(comando);
        }


        public static DataTable BusMaterias()
        {
            SqlCommand comando = MetodoDatos.CrearComando();
            comando.CommandText = "select Materia.Nombre from Materia where Profesor='Jose@gmail.com'";
            return MetodoDatos.EjecutarComandoSelect(comando);
        }

        public static List<Materia> ObtenerMaterias(String correo)
        {
            List<Materia> listaEmpleados = new List<Materia>();
            string sql = "select Materia.Nombre from Materia where Materia.Profesor='"+correo+"'";

            using (SqlConnection con = new SqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Materia materia = new Materia()
                            {
                                Nombre = reader.GetString(0),

                            };

                            listaEmpleados.Add(materia);
                        }
                    }
                }

                con.Close();

                return listaEmpleados;
            }



        }

       

    }
}

       
    
    
