using CADInmobiliaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ServicioWebInmobiliaria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceInmobiliaria : IServiceInmobiliaria
    {
        //metodo para insertar contacto.
        public void InsertContacto(string email, string contrasenya, string nombre, string apellido, string departamento, string municipio, string telefono, string celular)
        {
            DataBaseContacto.InsertContacto(email, contrasenya, nombre, apellido, departamento, municipio, telefono, celular);
        }
        //metodo para insertar imagenes.
        public void InsertImagenInmueble(byte[] imagenInmueble, int id_inmueble)
        {
            BaseDatosImagenes.InsertImagenInmueble(imagenInmueble, id_inmueble);
        }
        //metodos para insertar inmueble.
        public void InsertInmueble(string tipo_oferta, string tipo_inmueble, string ciudad_inmueble, string barrio_inmueble, string direccion_inmueble, decimal precio_inmueble, decimal area_inmueble, int numero_habitantes_inmueble, int numero_banyos_inmueble, int numero_habitaciones_inmuebles, int numero_pisos_inmueble, int antiguedad_inmueble, string estado_inmueble, string comentarios_inmueble, int id_contacto)
        {
            BaseDatosInmueble.InsertInmueble(tipo_oferta, tipo_inmueble, ciudad_inmueble, barrio_inmueble, direccion_inmueble, precio_inmueble, area_inmueble, numero_habitantes_inmueble,
                numero_banyos_inmueble, numero_habitaciones_inmuebles, numero_pisos_inmueble, antiguedad_inmueble, estado_inmueble, comentarios_inmueble, id_contacto);
        }
        //metodo seleccion contacto con toda la informacion de los inmuebles.
        public Contacto SelectContacto(int id_contacto)
        {
            DataSetBaseDatosInmobiliaria.contactoDataTable miTablaContacto = DataBaseContacto.SelectContacto(id_contacto);
            if (miTablaContacto.Rows.Count == 0) return null;
            DataSetBaseDatosInmobiliaria.contactoRow Registro = (DataSetBaseDatosInmobiliaria.contactoRow)miTablaContacto.Rows[0];
            Contacto miContacto = new Contacto();
            miContacto.email = Registro.email;
            miContacto.contrasenya = Registro.contrasenya;
            miContacto.nombre = Registro.nombre;
            miContacto.apellido = Registro.apellido;
            miContacto.departamento = Registro.departamento;
            miContacto.municipio = Registro.municipio;
            miContacto.telefono = Registro.telefono;

            //agrega la lista de inmuebles de este contacto.
            List<Inmueble> listaInmuebles = new List<Inmueble>();
            DataSetBaseDatosInmobiliaria.inmuebleDataTable miTablaInmueble = BaseDatosInmueble.SelectInmueble(id_contacto);
            if (miTablaInmueble.Rows.Count == 0)
            {
                listaInmuebles.Add(null);
            }
            else{
                foreach (DataSetBaseDatosInmobiliaria.inmuebleRow inmueble in miTablaInmueble.Rows)
                {
                    Inmueble miInmueble = new Inmueble();
                    miInmueble.idInmueble = inmueble.id_inmueble;
                    miInmueble.tipoOferta = inmueble.tipo_oferta;
                    miInmueble.tipoInmueble = inmueble.tipo_inmueble;
                    miInmueble.ciudadInmueble = inmueble.ciudad_inmueble;
                    miInmueble.barrioInmueble = inmueble.barrio_inmueble;
                    miInmueble.direccionInmueble = inmueble.barrio_inmueble;
                    miInmueble.precioInmueble = inmueble.precio_inmueble;
                    miInmueble.areaInmueble = inmueble.area_inmueble;
                    miInmueble.numeroHabitantes = inmueble.numero_habitantes_inmueble;
                    miInmueble.numeroBanyos = inmueble.numero_banyos_inmueble;
                    miInmueble.numeroHabitaciones = inmueble.numero_habitaciones_inmuebles;
                    miInmueble.numeroPisos = inmueble.numero_pisos_inmueble;
                    miInmueble.antiguedadInmueble = inmueble.antiguedad_inmueble;
                    miInmueble.estadoInmueble = inmueble.estado_inmueble;
                    miInmueble.comentariosInmuebles = inmueble.comentarios_inmueble;
                    miInmueble.idContacto = inmueble.id_contacto;
                    
                    //agrega la lista de imagenes del inmueble del contacto.
                    List<Imagen> listaImagenes = new List<Imagen>();
                    DataSetBaseDatosInmobiliaria.imagenesInmuebleDataTable miTablaImagenes = BaseDatosImagenes.SelectImagen(miInmueble.idInmueble);
                    if(miTablaImagenes.Rows.Count == 0)
                    {
                        listaImagenes.Add(null);
                    }
                    else
                    {
                        foreach (DataSetBaseDatosInmobiliaria.imagenesInmuebleRow imagenesInmueble in miTablaImagenes.Rows)
                        {
                            Imagen miImagen = new Imagen();
                            miImagen.idImagenInmueble = imagenesInmueble.id_imagenInmueble;
                            miImagen.imagenInmueble = imagenesInmueble.imagenInmueble;
                            miImagen.idInmueble = imagenesInmueble.id_inmueble;
                            listaImagenes.Add(miImagen);
                        }
                        miInmueble.listaImagen = listaImagenes;
                    }
                    listaInmuebles.Add(miInmueble);
                }
            }
            miContacto.listaInmuebles = listaInmuebles;
            return miContacto;
        }
        //meodo lista de inmuebles.
        public List<Inmueble> SelectListaInmuebles(string ciudad_inmueble)
        {
            DataSetBaseDatosInmobiliaria.inmuebleDataTable miTablaInmueble = BaseDatosInmueble.SelectListaInmuebles(ciudad_inmueble);
            List<Inmueble> listaInmuebles = new List<Inmueble>();
            if (miTablaInmueble.Rows.Count == 0) return null;

            foreach (DataSetBaseDatosInmobiliaria.inmuebleRow inmueble in miTablaInmueble.Rows)
            {
                Inmueble miInmueble = new Inmueble();
                miInmueble.idInmueble = inmueble.id_inmueble;
                miInmueble.tipoOferta = inmueble.tipo_oferta;
                miInmueble.tipoInmueble = inmueble.tipo_inmueble;
                miInmueble.ciudadInmueble = inmueble.ciudad_inmueble;
                miInmueble.barrioInmueble = inmueble.barrio_inmueble;
                miInmueble.direccionInmueble = inmueble.barrio_inmueble;
                miInmueble.precioInmueble = inmueble.precio_inmueble;
                miInmueble.areaInmueble = inmueble.area_inmueble;
                miInmueble.numeroHabitantes = inmueble.numero_habitantes_inmueble;
                miInmueble.numeroBanyos = inmueble.numero_banyos_inmueble;
                miInmueble.numeroHabitaciones = inmueble.numero_habitaciones_inmuebles;
                miInmueble.numeroPisos = inmueble.numero_pisos_inmueble;
                miInmueble.antiguedadInmueble = inmueble.antiguedad_inmueble;
                miInmueble.estadoInmueble = inmueble.estado_inmueble;
                miInmueble.comentariosInmuebles = inmueble.comentarios_inmueble;
                miInmueble.idContacto = inmueble.id_contacto;
                

                //agrega la lista de imagenes del inmueble del contacto.
                List<Imagen> listaImagenes = new List<Imagen>();
                DataSetBaseDatosInmobiliaria.imagenesInmuebleDataTable miTablaImagenes = BaseDatosImagenes.SelectImagen(miInmueble.idInmueble);
                if (miTablaImagenes.Rows.Count == 0)
                {
                    listaImagenes.Add(null);
                }
                else
                {
                    foreach (DataSetBaseDatosInmobiliaria.imagenesInmuebleRow imagenesInmueble in miTablaImagenes.Rows)
                    {
                        Imagen miImagen = new Imagen();
                        miImagen.idImagenInmueble = imagenesInmueble.id_imagenInmueble;
                        miImagen.imagenInmueble = imagenesInmueble.imagenInmueble;
                        miImagen.idInmueble = imagenesInmueble.id_inmueble;
                        listaImagenes.Add(miImagen);
                    }
                    miInmueble.listaImagen = listaImagenes;
                }
                listaInmuebles.Add(miInmueble);
            }
            return listaInmuebles;
        }

        //metodo verificacion login
        public int VerificacionLogin(string email, string contrasenya)
        {
            return DataBaseContacto.VerificacionLogin(email, contrasenya);
        }
    }
}
