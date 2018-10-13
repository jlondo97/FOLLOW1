﻿using System;
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
            //  string sql = "select Users.Nombre from users where Identificacion = '456789'and Nombre = 'Jose'";
            string sql = "select * from Materia";

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

        public static DataTable VerificarEstudiante(String Nombre, String Identificacion)
        {
            SqlCommand Comando = MetodoDatos.CrearComando();
            Comando.CommandText = "select Nombre, Identificacion from users where Nombre ='"+Nombre+"' and Identificacion='"+Identificacion+"'";
            return MetodoDatos.EjecutarSelect(Comando);
        }

    }
}
