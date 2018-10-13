using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace follow.Infrastructure
{
    public class AccesoDatosUsuario
    {
        public static int IngresarUsuario(string Correo, string Nombre, string Apellidos, string Identificacion, string Contraseña)
        {
            SqlCommand comando = MetodoDatos.CrearComandoProc("insUsuario");
            comando.Parameters.AddWithValue("@Correo", Correo);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Apellidos", Apellidos);
            comando.Parameters.AddWithValue("@Identificacion", Identificacion);
            comando.Parameters.AddWithValue("@Contraseña", Contraseña);

            return MetodoDatos.EjecutarComando(comando);
        }

        public static DataTable VerificarUsuario(String Correo, string contraseña)
        {
            SqlCommand Comando = MetodoDatos.CrearComando();
            Comando.CommandText = "select users.Nombre from users where users.Correo='"+Correo+"' and users.Contraseña='"+contraseña+"'";
            return MetodoDatos.EjecutarSelect(Comando);
        }
    }
}
