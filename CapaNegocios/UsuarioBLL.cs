using CapaDatos;
using CapaEntidades;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class UsuarioBLL
    {



        #region insObj
        private DataTable tb = new DataTable();
        AccesoDAL accesoDal = new AccesoDAL();
        #endregion

        #region MethodGetAllUsuarioNombre
        public UsuarioBE SelUsuarioId(int IdUsuario)
        {
            return accesoDal.SelUsuarioId(IdUsuario);

        }
        #endregion

        #region MethodAddUsuario
        public string InsUsuario(UsuarioBE obj)
        {

            return accesoDal.InsUsuario(obj);
        }
        #endregion

        #region MethodUpUsuario
        public void UpdUsuario(UsuarioBE obj)
        {
            accesoDal.UpdUsuario(obj);
        }
        #endregion

        #region MethodDeleteUsuario
        public void DelUsuario(CapaEntidades.UsuarioBE obj)
        {
            accesoDal.DelUsuario(obj);
        }
        #endregion

        #region MethodGetAllUsuario
        public List<UsuarioBE> SelUsuarios()
        {
            return accesoDal.SelUsuarios();

        }
        #endregion


    }
}
