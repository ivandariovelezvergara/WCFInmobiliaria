using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioWebInmobiliaria
{
    [DataContract]
    public class Inmueble
    {
        [DataMember] 
        public int idInmueble { get; set; }
        [DataMember]
        public string tipoOferta { get; set; }
        [DataMember]
        public string tipoInmueble { get; set; }
        [DataMember]
        public string ciudadInmueble { get; set; }
        [DataMember]
        public string barrioInmueble { get; set; }
        [DataMember]
        public string direccionInmueble { get; set; }
        [DataMember]
        public decimal precioInmueble { get; set; }
        [DataMember]
        public decimal areaInmueble { get; set; }
        [DataMember]
        public int numeroHabitantes { get; set; }
        [DataMember]
        public int numeroBanyos { get; set; }
        [DataMember]
        public int numeroHabitaciones { get; set; }
        [DataMember]
        public int numeroPisos { get; set; }
        [DataMember]
        public int antiguedadInmueble { get; set; }
        [DataMember]
        public string estadoInmueble { get; set; }
        [DataMember]
        public string comentariosInmuebles { get; set; }
        [DataMember]
        public int idContacto { get; set; }
        [DataMember]
        public List<Imagen> listaImagen { get; set; }

    }
}