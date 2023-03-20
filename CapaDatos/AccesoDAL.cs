using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static CapaDatos.conDB.conDB;

namespace CapaDatos
{
    public class AccesoDAL
    {
        private Conexion conexion = new Conexion();

        #region InsUsuario
        public string InsUsuario(UsuarioBE emp)
        {
            string mensaje = "";
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.OpenConexion();
                    comando.CommandText = "SP_Ins_US";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Us_nombre", SqlDbType.VarChar, 50).Value = Convert.ToString(emp.Us_nombre);
                    comando.Parameters.Add("@Us_fech_nacimiento", SqlDbType.Date).Value = emp.Us_fech_nacimiento;
                    comando.Parameters.Add("@Us_sexo", SqlDbType.VarChar, 1).Value = (emp.Us_sexo);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    comando.Connection = conexion.CloseConexion();

                }

            }
            catch (Exception ex)
            {
                mensaje = "Error" + ex;
            }

            return mensaje;
        }

        #endregion

        #region UpdUsuario
        public void UpdUsuario(UsuarioBE emp)
        {

            using (SqlCommand comando = new SqlCommand())
            {

                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "SP_Upd_US";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Us_id", SqlDbType.Int).Value = (emp.Us_id);
                comando.Parameters.Add("@Us_nombre", SqlDbType.VarChar, 100).Value = (emp.Us_nombre);
                comando.Parameters.Add("@Us_fech_nacimiento", SqlDbType.Date).Value = emp.Us_fech_nacimiento;
                comando.Parameters.Add("@Us_sexo", SqlDbType.VarChar, 1).Value = (emp.Us_sexo);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CloseConexion();


            }

        }

        #endregion

        #region DelUsuario
        public void DelUsuario(UsuarioBE obj)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "SP_Del_US";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Us_id", SqlDbType.Int).Value = (obj.Us_id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CloseConexion();

            }


        }

        #endregion

        #region SelUsuarios
        public List<UsuarioBE> SelUsuarios()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                List<UsuarioBE> items = new List<UsuarioBE>();

                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "SP_Sel_US";
                comando.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            UsuarioBE entity = new UsuarioBE();
                            entity.Us_id = (int)read["Us_id"];
                            entity.Us_nombre = read["Us_nombre"].ToString();
                            entity.Us_fech_nacimiento = Convert.ToDateTime(read["Us_fech_nacimiento"]);
                            entity.Us_sexo = (read["Us_sexo"].ToString());
                            items.Add(entity);
                        }

                    }
                }
                conexion.CloseConexion();
                return items;
            }

        }
        #endregion

        #region SelUsuarioId
        public UsuarioBE SelUsuarioId(int Us_id)
        {
            using (SqlCommand comando = new SqlCommand())
            {

                UsuarioBE entity = new UsuarioBE();
                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "SP_Sel_US_id";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Us_id", SqlDbType.Int).Value = Us_id;

                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            entity.Us_id = (int)read["Us_id"];
                            entity.Us_nombre = read["Us_nombre"].ToString();
                            entity.Us_fech_nacimiento = Convert.ToDateTime(read["Us_fech_nacimiento"]);
                            entity.Us_sexo = read["Us_sexo"].ToString();

                        }
                    }
                }
                conexion.CloseConexion();
                return entity;
            }
        }
        #endregion
    }
}
