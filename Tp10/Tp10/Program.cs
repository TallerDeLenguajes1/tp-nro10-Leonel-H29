using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tp10
{
    class Program
    {
        static DateTime Realizado = DateTime.Now;
        static String Fecha_Archivo = Convert.ToString(Realizado);
        static String[] partes_fecha = Fecha_Archivo.Split(new char[] { '/', ' ', ':' });
        static string Ruta = @"C:\Users\Aldo Herrera\Desktop\Taller\TP10\Propiedades" + partes_fecha[0] + partes_fecha[1] + partes_fecha[2] + partes_fecha[3] + partes_fecha[4] + partes_fecha[5] + ".csv";
        //static string Ruta = @"C:\Users\Aldo Herrera\Desktop\Taller\TP10\Propiedades.csv";
        static void Main(string[] args)
        {
            List<Propiedad> Propiedades = new List<Propiedad>();
            Console.WriteLine("--Ingrese la cantidad de inmuebles: ");
            int cant_prop = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < cant_prop; i++)
            {
                Cargar_Lista(Propiedades, i);
            }
            //Console.ReadKey();
            BackUp_Propiedades(Propiedades);
            Console.ReadKey();
        }
        static void Cargar_Lista(List<Propiedad> Propiedades, int i)
        {
            Propiedad Inmueble = new Propiedad();
            Inmueble = Cargar_Datos(i);
            Inmueble.Mostrar();
            Inmueble.GuardarEnArchivo(Ruta);
            Propiedades.Add(Inmueble);
        }

        static Propiedad Cargar_Datos(int i)
        {
            Propiedad Inmueble = new Propiedad();
            Random Aleatorio = new Random();

            Inmueble.Id = i + 1;
            Inmueble.Tamanio1 = Aleatorio.Next(10000, 30000);
            Inmueble.Cant_Banios1 = Aleatorio.Next(1, 4);
            Inmueble.Cant_Hab1 = Aleatorio.Next(1, 6);
            Inmueble.Domicilio1 = "Calle " + Aleatorio.Next(100, 2000);
            Inmueble.Precio1 = Aleatorio.Next(100000, 20000000);
            return Inmueble;
        }
        
        

        static void BackUp_Propiedades(List<Propiedad> Propiedades)
        {
            string[] discos = System.IO.Directory.GetLogicalDrives(); //Arreglo de los discos disponibles
            string BuscandoCarpeta = "BackUpPropiedades"; //Carpeta donde guardo
            string Archivo_back = @"\Propiedades" + partes_fecha[0] + partes_fecha[1] + partes_fecha[2] + partes_fecha[3] + partes_fecha[4] + partes_fecha[5] + ".bk"; //Archivo del backup
            string Archivo_Copia = @"\Prop_Copia" + partes_fecha[0] + partes_fecha[1] + partes_fecha[2] + partes_fecha[3] + partes_fecha[4] + partes_fecha[5] + ".csv"; //Copia del archivo original 

            Console.WriteLine("--Discos disponibles: ");
            foreach (string Disk in discos)
            {
                Console.WriteLine("--" + Disk);
            }
            Console.WriteLine("-En que disco desea guardar? ");
            char Disco_elegido = Convert.ToChar(Console.ReadLine());
            BuscandoCarpeta = Disco_elegido + @":\ " + BuscandoCarpeta;
            //---En caso de que la carpeta no exista
            if (!Directory.Exists(BuscandoCarpeta))
            {
                try { Directory.CreateDirectory(BuscandoCarpeta); }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex);
                    throw;
                }
            }
            Archivo_back = String.Concat(BuscandoCarpeta, Archivo_back);
            Archivo_Copia = String.Concat(BuscandoCarpeta, Archivo_Copia);
            while (File.Exists(Ruta)) {
                try
                {
                    File.Copy(Ruta, Archivo_Copia);
                    System.IO.File.Move(Archivo_Copia, Archivo_back);
                    if (!File.Exists(Archivo_Copia))
                    {
                        Console.WriteLine("--No se ha podido copiar el archivo");
                    }
                    else Console.WriteLine("--Archivo Copiado en: {0}\n", Archivo_Copia); ;
                    if (!File.Exists(Archivo_back))
                    {
                        Console.WriteLine("--No se ha podido crear el respaldo");
                    }
                    else Console.WriteLine("--Respaldo guardado en {0}\n", Archivo_back);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex);
                    throw;
                }
            }
        }
    }
}
