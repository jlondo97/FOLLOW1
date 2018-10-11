using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace follow.Infrastructure
{
    public class MetodoDatos
    {
        public static SqlCommand CrearComando()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _Conexion = new SqlConnection();
            _Conexion.ConnectionString = _cadenaConexion;
            SqlCommand _comando = new SqlCommand();
            _comando = _Conexion.CreateCommand();
            _comando.CommandType = CommandType.Text;
            return _comando;
        }


        public static SqlCommand CrearComandoProc(string proc)
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);
            SqlCommand _comando = new SqlCommand(proc, _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;

        }

        public static int EjecutarComando(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                return comando.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }
        public static DataTable EjecutarComandoSelect(SqlCommand comando)
        {
            DataTable _tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(_tabla);

            }
            catch { throw; }

            finally
            { comando.Connection.Close(); }
            return _tabla;

        }





        internal static DataTable EjecutarSelect(SqlCommand Comando)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = Comando;
                adaptador.Fill(Tabla);
            }
            catch
            {
                throw;
            }
            finally
            {
                Comando.Connection.Close();
            }
            return Tabla;
        }
    }
}
