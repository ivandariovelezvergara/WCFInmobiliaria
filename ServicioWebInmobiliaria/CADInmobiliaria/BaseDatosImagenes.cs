using CADInmobiliaria.DataSetBaseDatosInmobiliariaTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADInmobiliaria
{
    public class BaseDatosImagenes
    {
        
        private static imagenesInmuebleTableAdapter adapter = new imagenesInmuebleTableAdapter();
        //metodo Insertar Imagen
        public static void InsertImagenInmueble(byte[] imagenInmueble, int id_inmueble)
        {
            adapter.InsertImagenInmueble(imagenInmueble, id_inmueble);
        }
        //metodo select imagene
        public static DataSetBaseDatosInmobiliaria.imagenesInmuebleDataTable SelectImagen(int id_inmueble)
        {
           return adapter.SelectImagen(id_inmueble);
        }
    }
}
