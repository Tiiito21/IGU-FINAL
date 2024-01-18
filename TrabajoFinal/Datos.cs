using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;

namespace TrabajoFinalAlejandroAceves
{
    public class Datos
    {


        public Proceso importar(String fileName)
        {

            StreamReader reader = new StreamReader(fileName);
            String linea = "";
            bool firstLine = true;

            Proceso procesoAImportar = null;
            ObservableCollection<Partido> listaPartidos = new ObservableCollection<Partido>();

            while ((linea = reader.ReadLine()) != null)
            {
                //dividimos por el separador
                String[] campos = linea.Split(';');
                //ES LA INFORMACION DEL PROCESO
                if (firstLine)
                {
                    if (!int.TryParse(campos[2], out int valor) || !DateTime.TryParse(campos[1], out DateTime fecha))
                    {
                        return null;
                    }
                    else
                    {
                        //inicializamos el proceso
                        procesoAImportar = new Proceso(campos[0], fecha, valor, new ObservableCollection<Partido>());
                    }
                    firstLine = false;
                }
                //INFORMACION DE LOS PARTIDOS
                else
                {
                    if (!int.TryParse(campos[1], out int valor) || !int.TryParse(campos[2], out int R) || !int.TryParse(campos[3], out int G)
                        || !int.TryParse(campos[4], out int B))
                    {
                        return null;
                    }
                    else
                    {
                        Partido partido = new Partido(campos[0], valor, Color.FromRgb((byte)R, (byte)G, (byte)B));
                        listaPartidos.Add(partido);
                    }
                }
            }
            procesoAImportar.ListaPartidos = listaPartidos;
            reader.Close();
            return procesoAImportar;



        }
    }
}
