using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace follow.Infrastructure
{
  public class AccesoDatosMateria
    {

        public static int IngresarMateria(string Nombre, string Profe, string Grupo)
        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insMaterias");
            comando.Parameters.AddWithValue("@Nom", Nombre);
            comando.Parameters.AddWithValue("@Profe", Profe);
            comando.Parameters.AddWithValue("@grup", Grupo);
            
            return MetodoDatos.EjecutarComando(comando);
        }

    }
}
