
using System;
using System.Collections.ObjectModel;

namespace TrabajoFinalAlejandroAceves
{
    public class Proceso
    {
        public String Eleccion { get; set; }

        public DateTime FechaElecciones { get; set; }

        public int NumEscannos { get; set; }

        public int NumMayoria { get; set; }

        public ObservableCollection<Partido> ListaPartidos { get; set; }

        public Proceso(String eleccion, DateTime fechaElecciones, int numEscannos, ObservableCollection<Partido> partidos)
        {
            Eleccion = eleccion;
            FechaElecciones = fechaElecciones;
            NumEscannos = numEscannos;
            NumMayoria = numEscannos / 2 + 1;
            ListaPartidos = partidos;
        }

    }
}
