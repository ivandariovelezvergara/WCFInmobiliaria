using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWebInmobiliaria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceInmobiliaria
    {
        //insertar contacto
        [OperationContract]
        void InsertContacto(string email, string contrasenya, string nombre, string apellido, string departamento, string municipio, string telefono, string celular);
        //insertar inmueble
        [OperationContract]
        void InsertInmueble(string tipo_oferta, string tipo_inmueble, string ciudad_inmueble, string barrio_inmueble, string direccion_inmueble,
                    decimal precio_inmueble, decimal area_inmueble, int numero_habitantes_inmueble, int numero_banyos_inmueble, int numero_habitaciones_inmuebles,
                    int numero_pisos_inmueble, int antiguedad_inmueble, string estado_inmueble, string comentarios_inmueble, int id_contacto);
        //insertar imagen
        [OperationContract]
        void InsertImagenInmueble(byte[] imagenInmueble, int id_inmueble);
        //verificar login
        [OperationContract]
        int VerificacionLogin(string email, string contrasenya);
        //seleccionar contacto
        [OperationContract]
        Contacto SelectContacto(int id_contacto);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetProducts/",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<Inmueble> SelectListaInmuebles(string ciudad_inmueble);
    }

}
