using CADInmobiliaria.DataSetBaseDatosInmobiliariaTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADInmobiliaria
{
    public class DataBaseContacto
    {
        private static contactoTableAdapter Adapter = new contactoTableAdapter();
        //metodo insertar contacto
        public static void InsertContacto(string email, string contrasenya, string nombre, string apellido, string departamento, string municipio, string telefono, string celular)
        {
            Adapter.InsertContacto(email, contrasenya, nombre, apellido, departamento, municipio, telefono, celular);
        }
        //metodo verificacion login
        public static int VerificacionLogin(string email, string contrasenya)
        {
            try
            {
                return (int)Adapter.VerificacionLogin(email, contrasenya);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        //metodo select contacto
        public static DataSetBaseDatosInmobiliaria.contactoDataTable SelectContacto(int id_contacto)
        {
            return Adapter.SelectContacto(id_contacto);
        }
    }
}
