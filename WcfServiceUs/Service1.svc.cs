using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceUs
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        UsuarioBLL accesoBLL = new UsuarioBLL();

        public UsuarioBE getSelectUsId(int IdUsuario)
        {
            return accesoBLL.SelUsuarioId(IdUsuario);
        }

        public List<UsuarioBE> getSelectUs()
        {
            return accesoBLL.SelUsuarios();
        }

        public string setInsertUs(UsuarioBE obj)
        {
            return accesoBLL.InsUsuario(obj);
        }



        public void setUpdateUs(UsuarioBE obj)
        {
            accesoBLL.UpdUsuario(obj);
        }

        public void setDeleteUs(UsuarioBE obj)
        {
            accesoBLL.DelUsuario(obj);
        }


    }
}
