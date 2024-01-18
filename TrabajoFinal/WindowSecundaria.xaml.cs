using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TrabajoFinalAlejandroAceves
{
    /// <summary>
    /// Lógica de interacción para WindowSecundaria.xaml
    /// </summary>
    public class ProcesoEventArgs : EventArgs
    {
        public Proceso ProcesoSeleccionado { get; set; }

        public ProcesoEventArgs(Proceso procesoSeleccionado)
        {
            ProcesoSeleccionado = procesoSeleccionado;
        }
    }

    public partial class WindowSecundaria : Window
    {


        public event EventHandler<ProcesoEventArgs> procesoCambia;

        ObservableCollection<Proceso> listaProcesos;
        ProcesoMenu pm;

        //CONSTRUCTOR
        public WindowSecundaria(ObservableCollection<Proceso> procesos)
        {
            InitializeComponent();
            listaProcesos = procesos;
            TablaProcesos.ItemsSource = listaProcesos;
        }


        /*
         * METODOS EVENTO
         */
        private void Procesos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (TablaProcesos.SelectedItem != null)
            {
                Proceso procesoSeleccionado = (Proceso)TablaProcesos.SelectedItem;
                TablaProceso.ItemsSource = new ObservableCollection<Partido>(procesoSeleccionado.ListaPartidos.OrderByDescending(p => p.Num));
                //Permitimos poder modificar sus datos
                modProceso.IsEnabled = true;
                modProcesos.IsEnabled = true;
                eliProceso.IsEnabled = true;
                OnProcesoCambia(new ProcesoEventArgs(procesoSeleccionado));
            }
            else
            {
                TablaProceso.ItemsSource = null;

                //Si no hay proceso seleccionado no se puede borrar
                modProceso.IsEnabled = false;
                modProcesos.IsEnabled = false;
                eliProceso.IsEnabled = false;
                OnProcesoCambia(new ProcesoEventArgs(null));
            }
        }
        private void OnProcesoCambia(ProcesoEventArgs e)
        {

            procesoCambia?.Invoke(this, e);
        }


        /*
         * METODOS BOTONES RELACIONADOS CON PROCESOS
         */
        private void MenuAnnadirProceso_Click(object sender, RoutedEventArgs e)
        {
            pm = new ProcesoMenu(listaProcesos);
            pm.Owner = this;
            pm.ShowDialog();
        }

        private void MenuModProceso_Click(object sender, RoutedEventArgs e)
        {
            pm = new ProcesoMenu(listaProcesos, (Proceso)TablaProcesos.SelectedItem);
            pm.Owner = this;
            pm.ShowDialog();
        }

        private void MenuBorrarProceso_Click(object sender, RoutedEventArgs e)
        {
            if (TablaProcesos.SelectedItem != null)
            {
                Proceso aEliminar = (Proceso)TablaProcesos.SelectedItem;
                TablaProcesos.SelectedItem = null;

                listaProcesos.Remove(aEliminar);
            }
        }



        /*
         * METODOS IMPORTACION
         */
        private void MenuImportarProceso_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg;
            dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Proceso"; // Nombre por defecto
            dlg.DefaultExt = ".process"; // Extensión por defecto
            dlg.Filter = "Proceso Electoral(.process)|*.process"; // Filtro
            //Devuelve nulo si no se realiza accion
            Boolean? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                Datos d = new Datos();
                Proceso p = d.importar(filename);
                if (p != null)
                {
                    if (procesoExiste(p))
                    {
                        MessageBox.Show("El proceso ya existe en la lista", "Proceso Duplicado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        listaProcesos.Add(p);
                    }
                }
                else
                {
                    MessageBox.Show("Error al importar proceso", "Error de Importacion", MessageBoxButton.OKCancel);
                }
            }



        }



        /*
         * METODOS UTILES
         */
        private Boolean procesoExiste(Proceso proceso)
        {
            foreach (Proceso p in listaProcesos)
            {
                if (p.Eleccion.Equals(proceso.Eleccion))
                {
                    return true;
                }
            }
            return false;
        }


    }

}
