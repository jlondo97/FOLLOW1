using System;
using System.Collections.Generic;
using System.Text;

namespace follow.Infrastructure
{
    public class Configuracion
    {
        static string cadenaConexion = "Data Source=followserver.database.windows.net;" +
                    "Initial Catalog=FollowDB;" +
                    "User id=FollowSa;" +
                    "Password=Follow.2018;";
        public static string CadenaConexion
        {
            get { return cadenaConexion; }
        }
    }
}
