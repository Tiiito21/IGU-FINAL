using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrabajoFinalAlejandroAceves
{
    /// <summary>
    /// Lógica de interacción para CrearProceso.xaml
    /// </summary>
    public partial class ProcesoMenu : Window
    {
        Boolean modificando = false;
        PartidoMenu WindowMenu;


        ObservableCollection<Proceso> procesos;
        ObservableCollection<Partido> listaPartidos = new ObservableCollection<Partido>();
        ObservableCollection<Partido> copiaRestaurar = new ObservableCollection<Partido>();
        Proceso procesoAntiguo;
        Proceso process;

        /*
         * CONSTRUCTORES
         */
        public ProcesoMenu(ObservableCollection<Proceso> lista)
        {
            InitializeComponent();
            procesos = lista;
            TablaPartidos.ItemsSource = listaPartidos;
        }
 
        public ProcesoMenu(ObservableCollection<Proceso> lista, Proceso selected)
        {
            InitializeComponent();
            procesos = lista;
            modificando = true;
            process = selected;
            procesoAntiguo = selected;

            //Hacemos una copia profunda de la lista por si rechazamos
            foreach (Partido p in process.ListaPartidos)
            {
                copiaRestaurar.Add(new Partido(p.NombrePartido, p.Num, Color.FromRgb(p.Color.R, p.Color.G, p.Color.B)));

            }

            name.Text = process.Eleccion;
            date.SelectedDate = process.FechaElecciones;
            numDip.Text = process.NumEscannos.ToString();
            listaPartidos = process.ListaPartidos;
            TablaPartidos.ItemsSource = listaPartidos;

        }

        /*
         * METODOS BOTONES
         */
        private void Aceptar_Button_Click(object sender, RoutedEventArgs e)
        {

            //solo se añaden valores
            int i = 0;
            string s = numDip.Text;

            bool result = int.TryParse(s, out i);
            if (result == false || i <= 0)
            {
                MessageBox.Show("El numero de diputados debe de ser un numero mayor que 0", "Error en los datos", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            else
            {
                if (date.SelectedDate == null)
                {
                    MessageBox.Show("Debes elegir una fecha", "Error en los datos", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
                else
                {
                    if (name.Text == "")
                    {
                        MessageBox.Show("El nombre no puede estar vacio", "Error en los datos", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (comprobarValidez())
                        {
                            DateTime fecha = DateTime.Parse(date.Text);
                            process = new Proceso(name.Text, fecha, i, listaPartidos);

                            if (modificando == true)
                            {
                                procesos.Remove(procesoAntiguo);
                            }
                            procesos.Add(process);
                            DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("El numero de diputados no coincide con el numero de representantes de todos los partidos", "Error en los datos", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        }

                    }

                }
            }

        }
        private void Rechazar_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modificando)
            {
                process.ListaPartidos = copiaRestaurar;
            }
            DialogResult = false;
        }


        /*
         * METODOS BOTONES PARTIDOS
         */
        private void AddPartido_Click(object sender, RoutedEventArgs e)
        {
            WindowMenu = new PartidoMenu(listaPartidos);
            WindowMenu.Owner = this;
            WindowMenu.ShowDialog();
        }

        private void ModPartido_Click(object sender, RoutedEventArgs e)
        {
            WindowMenu = new PartidoMenu(listaPartidos, (Partido)TablaPartidos.SelectedItem);
            WindowMenu.Owner = this;
            WindowMenu.ShowDialog();
        }

        private void BorrarPartido_Click(object sender, RoutedEventArgs e)
        {

            if (TablaPartidos.SelectedItem != null)
            {
                Partido aEliminar = (Partido)TablaPartidos.SelectedItem;
                TablaPartidos.SelectedItem = null;

                listaPartidos.Remove(aEliminar);
            }

        }

        /*
         * METODOS VALIDEZ
         */
        private Boolean comprobarValidez()
        {
            int total = 0;
            int numDipEntero = 0;
            string s = numDip.Text;

            if (int.TryParse(s, out numDipEntero))
            {

                foreach (Partido part in listaPartidos)
                {
                    total += part.Num;
                }


                if (total == numDipEntero)
                {
                    //el numero de diputados es el mismo que el numero total de escaños de todos los partidos (es valido el proceso)
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        /*
         * METODOS EVENTARGS
         */
        private void TablaPartidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TablaPartidos.SelectedItem != null)
            {
                modificarPartido.IsEnabled = true;
                eliminarPartido.IsEnabled = true;
            }
            else
            {
                modificarPartido.IsEnabled = false;
                eliminarPartido.IsEnabled = false;
            }
        }
        private void NumDip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(numDip.Text, out int valor))
            {
                // Si el valor es un número válido, duplica el valor y actualiza el TextBox1
                numMayoria.Text = (valor / 2 + 1).ToString();
            }
            else
            {
                // Maneja el caso en que el valor no sea un número válido (puedes mostrar un mensaje de error, por ejemplo)
                numMayoria.Text = "Error";
            }
        }
    }
}
