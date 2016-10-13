using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioWebInmobiliaria
{
    [DataContract]
    public class Imagen
    {
        [DataMember]
        public int idImagenInmueble { get; set; }
        [DataMember]
        public byte[] imagenInmueble { get; set; }
        [DataMember]
        public int idInmueble { get; set; }
    }
}
