using CADInmobiliaria.DataSetBaseDatosInmobiliariaTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADInmobiliaria
{
    public class BaseDatosInmueble
    {
        private static inmuebleTableAdapter adapter = new inmuebleTableAdapter();
        //metodo insertar inmueble
        public static void InsertInmueble(string tipo_oferta, string tipo_inmueble, string ciudad_inmueble, string barrio_inmueble, string direccion_inmueble, 
                    decimal precio_inmueble, decimal area_inmueble, int numero_habitantes_inmueble, int numero_banyos_inmueble, int numero_habitaciones_inmuebles, 
                    int numero_pisos_inmueble, int antiguedad_inmueble, string estado_inmueble, string comentarios_inmueble, int id_contacto)
        {
            adapter.InsertInmueble(tipo_oferta, tipo_inmueble, ciudad_inmueble, barrio_inmueble, direccion_inmueble, precio_inmueble, area_inmueble, numero_habitantes_inmueble, 
                numero_banyos_inmueble, numero_habitaciones_inmuebles, numero_pisos_inmueble, antiguedad_inmueble, estado_inmueble, comentarios_inmueble, id_contacto);
        }
        //metodo seleccionar inmueble
        public static DataSetBaseDatosInmobiliaria.inmuebleDataTable SelectInmueble(int id_contacto)
        {
            return adapter.SelectInmueble(id_contacto);
        }
        //metodo lista imagenes
        public static DataSetBaseDatosInmobiliaria.inmuebleDataTable SelectListaInmuebles(string ciudad_inmueble)
        {
            return adapter.SelectListaInmuebles(ciudad_inmueble);
        }
    }
}
