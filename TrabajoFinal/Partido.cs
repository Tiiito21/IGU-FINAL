using System;
using System.Windows.Media;

namespace TrabajoFinalAlejandroAceves
{
    public class Partido
    {
        public String NombrePartido { get; set; }

        public int Num { get; set; }

        public Color Color { get; set; }
        public Partido(String nombrePartido, int num, Color color)
        {
            NombrePartido = nombrePartido;
            Num = num;
            Color = color;
        }
    }

}
