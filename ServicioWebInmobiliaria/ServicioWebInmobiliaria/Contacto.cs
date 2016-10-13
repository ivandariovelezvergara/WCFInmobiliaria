using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioWebInmobiliaria
{
    [DataContract]
    public class Contacto
    {
        [DataMember]
        public int idContacto { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string contrasenya { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellido { get; set; }
        [DataMember]
        public string departamento { get; set; }
        [DataMember]
        public string municipio { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string celular { get; set; }
        [DataMember]
        public List<Inmueble> listaInmuebles { get; set; }
    }
}