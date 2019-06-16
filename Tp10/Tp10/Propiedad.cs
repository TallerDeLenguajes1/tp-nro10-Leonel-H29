using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tp10
{
    public enum TipoDeOperacion { Venta, Alquiler };
    public enum TipoDePropiedad { Departamento, Casa, Duplex, Penthhouse, Terreno };


    class Propiedad
    {
        private int id;
        private TipoDeOperacion _Operacion;
        private TipoDePropiedad _Propiedad;
        private float Tamanio;
        private int Cant_Banios;
        private int Cant_Hab;
        private string Domicilio;
        private int Precio;
        //private bool Estado; //Activo o inactivo

        public Propiedad()
        {
            Random Aleatorio = new Random();
            TipoDeOperacion Op = (TipoDeOperacion)Aleatorio.Next(0,1);
            _Operacion = Op;
            TipoDePropiedad Prop = (TipoDePropiedad)Aleatorio.Next(0, 4);
            _Propiedad = Prop;
        }

        public Propiedad(int _id, TipoDeOperacion _op,TipoDePropiedad _prop, float _tam, int _banios, int _hab, string _dom, int _precio) {
            this.id = _id;
            this._Operacion = _op;
            this._Propiedad = _prop;
            this.Tamanio = _tam;
            this.Cant_Banios = _banios;
            this.Cant_Hab = _hab;
            this.Domicilio = _dom;
            this.Precio = _precio;
        }

        public int Id { get => id; set => id = value; }
        public float Tamanio1 { get => Tamanio; set => Tamanio = value; }
        public int Cant_Banios1 { get => Cant_Banios; set => Cant_Banios = value; }
        public int Cant_Hab1 { get => Cant_Hab; set => Cant_Hab = value; }
        public string Domicilio1 { get => Domicilio; set => Domicilio = value; }
        public int Precio1 { get => Precio; set => Precio = value; }

        public float Valordelinmueble() {
            String Prop = Convert.ToString(_Propiedad) ;
            float Precio_Op = Precio;
            switch (Prop)
            {
                case "Venta":
                    Precio_Op = Precio_Op + (float)0.31 + 10000;
                    break;
                case "Alquiler":
                    Precio_Op = Precio_Op + (float)0.025;
                    break;
            }
            return Precio_Op;
        }

        public void Mostrar()
        {
            string Contenido = String.Format("{0}) - {1} - {2} - {3} - {4} - {5} - {6} - ${7} - ${8}\n", Id, _Operacion,_Propiedad, Tamanio, Cant_Banios, Cant_Hab, Domicilio, Precio, Valordelinmueble()); 
            Console.WriteLine(Contenido);
        }

        public void GuardarEnArchivo(string Ruta)
        {
            StreamWriter Escribir_Archivo = new StreamWriter(Ruta, true);

            if (!File.Exists(Ruta))
            {
                try { File.Create(Ruta); }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : {0}", ex);
                    throw;
                }
            }
            try
            {
                using (Escribir_Archivo)
                {
                    string Contenido = String.Format("{0}) - {1} - {2} - {3} - {4} - {5} - {6} - ${7} - ${8}\n", Id, _Operacion, _Propiedad, Tamanio, Cant_Banios, Cant_Hab, Domicilio, Precio, Valordelinmueble());
                    Escribir_Archivo.Write(Contenido);
                    Escribir_Archivo.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
                throw;
            }
        }
    }
}
