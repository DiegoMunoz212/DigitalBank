using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.conDB
{
    public class conDB
    {
        public class Conexion
        {

            #region conDB
            private SqlConnection Con = new SqlConnection("Server=MPC-5KPJ\\MSSQLSERVERA; DataBase=digitalbankst;Integrated Security=true ; Encrypt=False");

            #endregion

            #region MethodOpen 
            public SqlConnection OpenConexion()
            {
                    if (Con.State == ConnectionState.Closed)
                        Con.Open();
                    return Con;
                
              
            }
            #endregion


            public SqlConnection CloseConexion()
            {
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                    return Con;
               
            }

        }
    }
}
