using System;
using System.Collections.Generic;
using System.Text;
using follow.View.EducadoresView;
using System.Data.SqlClient;

namespace follow.Infrastructure
{
   public class AccesoDatosTarea
    {
        public static int IngresarTarea(string Nombre, string Descripcion , string Fecha_inicio,
            string Fecha_final,string Grupo)
        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insTarea");

            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            comando.Parameters.AddWithValue("@Fecha_final", Fecha_final);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Grupo", Grupo);

            return MetodoDatos.EjecutarComando(comando);
        }
    }
}
