using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TrabajoFinalAlejandroAceves
{

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        /*
            VARIABLES GLOBALES
        */

        WindowSecundaria VentanaDatos;

        ObservableCollection<Proceso> listaProcesos = new ObservableCollection<Proceso>();
        ObservableCollection<Partido> listaSeleccionados = new ObservableCollection<Partido>();
        ObservableCollection<Partido> listaNoSeleccionados = new ObservableCollection<Partido>();
        int mayoria;


        /*
            INICIALIZACION
        */
        public MainWindow()
        {
            InitializeComponent();
            VentanaDatos = new WindowSecundaria(listaProcesos);
            VentanaDatos.procesoCambia += recibirSeleccionado;
            VentanaDatos.Closed += VentanaDatos_Closed;
            VentanaDatos.Show();
        }



        /*
            METODOS BOTONES
        */
        private void Config_Click(object sender, RoutedEventArgs e)
        {

            VentanaDatos = new WindowSecundaria(listaProcesos);
            VentanaDatos.procesoCambia += recibirSeleccionado;
            VentanaDatos.Closed += Acabar;
            VentanaDatos.Show();
            config.IsEnabled = false;
        }


        /*
            EVENTOS
        */

        private void recibirSeleccionado(Object sender, ProcesoEventArgs e)
        {
            if (e.ProcesoSeleccionado == null)
            {
                reiniciarGraficaProceso();
                reiniciarGraficaComparativa();
                reiniciarGraficoPactometro();
            }
            else
            {
                crearGraficaProceso(e.ProcesoSeleccionado);
                crearGraficaComparativa(e.ProcesoSeleccionado);
                crearPactometro(e.ProcesoSeleccionado);
            }
        }


        /*
            METODOS GRAFICOS
        */
        private void crearGraficaProceso(Proceso proceso)
        {
            reiniciarGraficaProceso();
            //si no hay seleccionado se reinicia la grafica unicamente sin elementos
            if (proceso == null)
            {
                return;
            }

            ObservableCollection<Partido> listaPartidosProceso = new ObservableCollection<Partido>(proceso.ListaPartidos.OrderByDescending(p => p.Num));

            int valorMax = 0;

            nombreProceso.Text = proceso.Eleccion;

            //obtenemos el valor maximo
            foreach (Partido partido in listaPartidosProceso)
            {
                if (partido.Num > valorMax)
                {
                    valorMax = partido.Num;
                }
            }
            Maximo.Text = valorMax.ToString();
            TresCuartos.Text = (valorMax / 4 * 3).ToString();
            Medio.Text = (valorMax / 2).ToString();
            Cuarto.Text = (valorMax / 4).ToString();


            int numPartidos = listaPartidosProceso.Count();

            int ancho = ((int)ejeAbscisas.X2 - (int)ejeAbscisas.X1) / numPartidos;
            int coord = 65;

            foreach (Partido partido in listaPartidosProceso)
            {
                Rectangle rectangulo = new Rectangle();
                rectangulo.Fill = new SolidColorBrush(partido.Color);
                rectangulo.Height = (partido.Num * 560) / valorMax; //hacemos la proporcion
                rectangulo.Width = ancho / 15 * 14;

                //tooltip al pasar x encima
                ToolTip rectanguloToolTip = new ToolTip();
                rectanguloToolTip.Content = partido.Num.ToString() + " Escaños";

                rectangulo.ToolTip = rectanguloToolTip;

                Canvas.SetTop(rectangulo, 580 - ((partido.Num * 560) / valorMax));
                Canvas.SetLeft(rectangulo, coord);

                //añadimos el nombre
                Label name = new Label();
                name.FontSize = 12;
                name.Content = partido.NombrePartido;
                Canvas.SetTop(name, 580 + 5);
                Canvas.SetLeft(name, coord);


                // Agregar el rectángulo al Canvas
                canvasTablaProceso.Children.Add(rectangulo);
                canvasTablaProceso.Children.Add(name);

                // Aumentar las coordenadas para el próximo rectángulo (puedes ajustar esto según sea necesario)
                coord += ancho;
            }
        }

        private void reiniciarGraficaProceso()
        {

            nombreProceso.Text = "Seleccione un Proceso Electoral";
            Maximo.Text = 100.ToString();
            TresCuartos.Text = 75.ToString();
            Medio.Text = 50.ToString();
            Cuarto.Text = 25.ToString();

            List<UIElement> rectangulosEliminar = new List<UIElement>();
            List<UIElement> labelEliminar = new List<UIElement>();

            //iteramos por los elementos del canvas para añadir a la lista de eliminar todos los rectangulos actuales
            foreach (UIElement elemento in canvasTablaProceso.Children)
            {
                if (elemento.GetType() == typeof(Rectangle))
                {
                    rectangulosEliminar.Add(elemento);
                }
                if (elemento.GetType() == typeof(Label))
                {
                    labelEliminar.Add(elemento);
                }
            }

            // Eliminamos los elementos añadidos antes, se hace asi porque no se puede eliminar elementos mientras se itera
            foreach (UIElement elemento in rectangulosEliminar)
            {
                canvasTablaProceso.Children.Remove(elemento);
            }
            foreach (UIElement elemento in labelEliminar)
            {
                canvasTablaProceso.Children.Remove(elemento);
            }
        }

        private void crearGraficaComparativa(Proceso proceso)
        {
            reiniciarGraficaComparativa();
            if (listaProcesos == null || listaProcesos.Count == 0 || proceso == null)
            {
                //si la lista esta vacia o es nula, no hace nada
                return;
            }

            nombreComparacion.Text = proceso.Eleccion;
            int valorMax = 0;


            //obtenemos el valor maximo de entre todos
            foreach (Proceso procesoActual in listaProcesos)
            {
                foreach (Partido partido in procesoActual.ListaPartidos)
                {
                    if (valorMax < partido.Num)
                    {
                        if (comprobarExiste(partido, proceso) >= 0)
                        {
                            valorMax = partido.Num;
                        }
                    }
                }
            }
            MaximoComparativa.Text = valorMax.ToString();
            TresCuartosComparativa.Text = (valorMax / 4 * 3).ToString();
            MedioComparativa.Text = (valorMax / 2).ToString();
            CuartoComparativa.Text = (valorMax / 4).ToString();

            //calculamos numero de rectangulos totales
            int numRectangulos = proceso.ListaPartidos.Count() * listaProcesos.Count();
            int ancho = ((int)ejeAbscisasC.X2 - (int)ejeAbscisasC.X1) / numRectangulos;
            int coord = 65;

            ObservableCollection<Partido> listaPartidosComparativa = new ObservableCollection<Partido>(proceso.ListaPartidos.OrderByDescending(p => p.Num));
            foreach (Partido partidoProceso in listaPartidosComparativa)
            {
                coord = listaPartidosComparativa.IndexOf(partidoProceso) * listaProcesos.Count() * ancho + 65;
                Rectangle rectangulo = new Rectangle();
                rectangulo.Fill = new SolidColorBrush(partidoProceso.Color);
                rectangulo.Height = (partidoProceso.Num * 560) / valorMax; //hacemos la proporcion
                rectangulo.Width = ancho / 15 * 14;

                //tooltip al pasar x encima
                ToolTip rectanguloToolTip = new ToolTip();
                rectanguloToolTip.Content = proceso.Eleccion + " " + partidoProceso.Num.ToString() + " Escaños";

                rectangulo.ToolTip = rectanguloToolTip;

                Canvas.SetTop(rectangulo, 580 - ((partidoProceso.Num * 560) / valorMax));
                Canvas.SetLeft(rectangulo, coord);

                Label name = new Label();
                name.Content = partidoProceso.NombrePartido;
                name.FontSize = 12;
                Canvas.SetTop(name, 580 + 5);
                Canvas.SetLeft(name, coord);



                // Agregar el rectángulo al Canvas
                canvasTablaComparativa.Children.Add(rectangulo);
                canvasTablaComparativa.Children.Add(name);
            }


            ObservableCollection<Proceso> listaSinSeleccionado = new ObservableCollection<Proceso>();
            foreach (Proceso process in listaProcesos)
            {
                if (process != proceso)
                {
                    listaSinSeleccionado.Add(process);
                }
            }
            foreach (Proceso procesoActual in listaSinSeleccionado)
            {
                foreach (Partido partidoPosible in procesoActual.ListaPartidos)
                {
                    int indice = comprobarExiste(partidoPosible, proceso);
                    if (indice > -1)
                    {
                        coord = 65 + ancho * listaProcesos.Count() * indice + (listaSinSeleccionado.IndexOf(procesoActual) + 1) * ancho;
                        Rectangle rectanguloExterno = new Rectangle();
                        rectanguloExterno.Fill = new SolidColorBrush(partidoPosible.Color);
                        rectanguloExterno.Height = (partidoPosible.Num * 560) / valorMax; //hacemos la proporcion
                        rectanguloExterno.Width = ancho / 15 * 14;

                        //tooltip al pasar x encima
                        ToolTip rectanguloExternoToolTip = new ToolTip();
                        rectanguloExternoToolTip.Content = procesoActual.Eleccion + " " + partidoPosible.Num.ToString() + " Escaños";

                        rectanguloExterno.ToolTip = rectanguloExternoToolTip;

                        Canvas.SetTop(rectanguloExterno, 580 - ((partidoPosible.Num * 560) / valorMax));
                        Canvas.SetLeft(rectanguloExterno, coord);


                        // Agregar el rectángulo al Canvas
                        canvasTablaComparativa.Children.Add(rectanguloExterno);
                    }

                }
            }
        }

        private void reiniciarGraficaComparativa()
        {
            nombreComparacion.Text = "Seleccione un Proceso Electoral";
            MaximoComparativa.Text = 100.ToString();
            TresCuartosComparativa.Text = 75.ToString();
            MedioComparativa.Text = 50.ToString();
            CuartoComparativa.Text = 25.ToString();

            List<UIElement> rectangulosEliminar = new List<UIElement>();
            List<UIElement> labelEliminar = new List<UIElement>();
            //iteramos por los elementos del canvas para añadir a la lista de eliminar todos los rectangulos actuales
            foreach (UIElement elemento in canvasTablaComparativa.Children)
            {
                if (elemento.GetType() == typeof(Rectangle))
                {
                    rectangulosEliminar.Add(elemento);
                }
                if (elemento.GetType() == typeof(Label))
                {
                    labelEliminar.Add(elemento);
                }
            }

            // Eliminamos los elementos añadidos antes, se hace asi porque no se puede eliminar elementos mientras se itera
            foreach (UIElement elemento in rectangulosEliminar)
            {
                canvasTablaComparativa.Children.Remove(elemento);
            }
            foreach (UIElement elemento in labelEliminar)
            {
                canvasTablaComparativa.Children.Remove(elemento);
            }
        }

        private void crearPactometro(Proceso proceso)
        {
            reiniciarGraficoPactometro();
            if (proceso == null)
            {
                return;
            }

            nombrePactometro.Text = proceso.Eleccion;


            ObservableCollection<Partido> listaPartidosPactometro = new ObservableCollection<Partido>(proceso.ListaPartidos.OrderByDescending(p => p.Num));
            int escannosNoSeleccionados = 0;



            foreach (Partido partido in listaPartidosPactometro)
            {
                if (partido.Num >= proceso.NumMayoria)
                {
                    listaSeleccionados.Add(partido);
                }
                else
                {
                    escannosNoSeleccionados += partido.Num;
                    listaNoSeleccionados.Add(partido);
                }

            }

            int valorMax = 0;
            int numEscannos = proceso.NumEscannos;

            foreach (Partido partido in listaNoSeleccionados)
            {
                if (valorMax < partido.Num)
                {
                    if (comprobarExiste(partido, proceso) >= 0)
                    {
                        valorMax = partido.Num;
                    }
                }
            }

            mayoria = proceso.NumMayoria;

            //ya hay mayoria
            if (listaSeleccionados.Count() > 0)
            {
                //creamos los rectangulos de la derecha
                foreach (Partido partido in listaNoSeleccionados)
                {
                    Rectangle rectangulo = new Rectangle();
                    rectangulo.Width = 100;
                    rectangulo.Fill = new SolidColorBrush(partido.Color);
                    rectangulo.Height = partido.Num * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / listaSeleccionados[0].Num;
                    rectangulo.MouseLeftButtonDown += Rectangle_MouseDown;
                    rectangulo.Tag = partido;
                    ToolTip rectanguloToolTip = new ToolTip();
                    rectanguloToolTip.Content = partido.NombrePartido + " - " + partido.Num.ToString();

                    rectangulo.ToolTip = rectanguloToolTip;

                    noSeleccionado.Children.Add(rectangulo);
                }


                lineaMayoria.Y1 = (gridPactometro.RowDefinitions[1].ActualHeight) - (proceso.NumMayoria * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / listaSeleccionados[0].Num); ;
                lineaMayoria.Y2 = (gridPactometro.RowDefinitions[1].ActualHeight) - (proceso.NumMayoria * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / listaSeleccionados[0].Num); ;
                lineaMayoria.X1 = 0;
                lineaMayoria.X2 = this.ActualWidth;
                lineaMayoria.Stroke = new SolidColorBrush(Colors.Black);
                lineaMayoria.StrokeThickness = 2;

                numMayoria.Text = 0 + "/" + proceso.NumMayoria.ToString();
                numMayoria.HorizontalAlignment = HorizontalAlignment.Left;
                numMayoria.Height = (gridPactometro.RowDefinitions[1].ActualHeight - 15) * proceso.NumMayoria / listaSeleccionados[0].Num;
                numMayoria.FontSize = 20;
                numMayoria.FontWeight = FontWeights.Bold;



                Rectangle rectanguloMayoria = new Rectangle();
                rectanguloMayoria.Width = 100;
                rectanguloMayoria.Fill = new SolidColorBrush(listaSeleccionados[0].Color);
                Console.WriteLine(proceso.NumEscannos - listaSeleccionados[0].Num);
                rectanguloMayoria.Height =  (gridPactometro.RowDefinitions[1].ActualHeight - 15);
                rectanguloMayoria.MouseLeftButtonDown += Rectangle_MouseDown;
                rectanguloMayoria.Tag = listaSeleccionados[0];

                //tooltip al pasar x encima
                ToolTip rectanguloToolTipMayoria = new ToolTip();
                rectanguloToolTipMayoria.Content = listaSeleccionados[0].NombrePartido + " - " + listaSeleccionados[0].Num.ToString();

                rectanguloMayoria.ToolTip = rectanguloToolTipMayoria;


                Seleccionado.Children.Add(rectanguloMayoria);
                numMayoria.Text = listaSeleccionados[0].Num.ToString() + "/" + proceso.NumMayoria.ToString();
                MessageBox.Show("Se ha alcanzado mayoria absoluta por una coalicion formada por el partido: " + listaSeleccionados[0].NombrePartido, "COALICION ALCANZADA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            else
            {
                //creamos los rectangulos de la derecha
                foreach (Partido partido in listaNoSeleccionados)
                {
                    Rectangle rectangulo = new Rectangle();
                    rectangulo.Width = 100;
                    rectangulo.Fill = new SolidColorBrush(partido.Color);
                    rectangulo.Height = partido.Num * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / escannosNoSeleccionados;
                    rectangulo.MouseLeftButtonDown += Rectangle_MouseDown;
                    rectangulo.Tag = partido;
                    ToolTip rectanguloToolTip = new ToolTip();
                    rectanguloToolTip.Content = partido.NombrePartido + " - " + partido.Num.ToString();

                    rectangulo.ToolTip = rectanguloToolTip;

                    noSeleccionado.Children.Add(rectangulo);
                }

                lineaMayoria.Y1 = (gridPactometro.RowDefinitions[1].ActualHeight) - (proceso.NumMayoria * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / escannosNoSeleccionados); ;
                lineaMayoria.Y2 = (gridPactometro.RowDefinitions[1].ActualHeight) - (proceso.NumMayoria * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / escannosNoSeleccionados); ;
                lineaMayoria.X1 = 0;
                lineaMayoria.X2 = this.ActualWidth;
                lineaMayoria.Stroke = new SolidColorBrush(Colors.Black);
                lineaMayoria.StrokeThickness = 2;

                numMayoria.Text = 0 + "/" + proceso.NumMayoria.ToString();
                numMayoria.HorizontalAlignment = HorizontalAlignment.Left;
                numMayoria.Height = (gridPactometro.RowDefinitions[1].ActualHeight - 15) * proceso.NumMayoria / escannosNoSeleccionados;
                numMayoria.FontSize = 20;
                numMayoria.FontWeight = FontWeights.Bold;
            }



        }

        private void reiniciarGraficoPactometro()
        {
            nombrePactometro.Text = "Seleccione un Proceso Electoral";
            numMayoria.Text = "";
            lineaMayoria.X2 = 0;

            listaNoSeleccionados.Clear();
            listaSeleccionados.Clear();

            List<UIElement> rectangulosEliminar = new List<UIElement>();

            //iteramos por los elementos del WrapPanel para añadir a la lista de eliminar todos los rectangulos actuales
            foreach (UIElement elemento in noSeleccionado.Children)
            {
                if (elemento.GetType() == typeof(Rectangle))
                {
                    rectangulosEliminar.Add(elemento);
                }
            }
            foreach (UIElement elemento in Seleccionado.Children)
            {
                if (elemento.GetType() == typeof(Rectangle))
                {
                    rectangulosEliminar.Add(elemento);
                }
            }

            // Eliminamos los elementos añadidos antes, se hace asi porque no se puede eliminar elementos mientras se itera
            foreach (UIElement elemento in rectangulosEliminar)
            {
                if (noSeleccionado.Children.Contains(elemento))
                {
                    noSeleccionado.Children.Remove(elemento);
                }
                else if (Seleccionado.Children.Contains(elemento))
                {
                    Seleccionado.Children.Remove(elemento);
                }

            }
        }

        /*
            METODOS UTILES
        */
        private int comprobarExiste(Partido partidoComprobar, Proceso principal)
        {

            foreach (Partido partido in principal.ListaPartidos)
            {
                if (partido.NombrePartido.Equals(partidoComprobar.NombrePartido))
                {
                    return principal.ListaPartidos.IndexOf(partido);
                }
            }

            return -1;
        }

        /*
            METODOS SECUNDARIOS
        */

        //si se cierra la principal se acaba la ejecucion
        private void Acabar(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void VentanaDatos_Closed(object sender, EventArgs e)
        {
            config.IsEnabled = true;

        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //cuando se presiona el click izquierdo
            if (sender is Rectangle rectangulo)
            {
                DependencyObject padre = VisualTreeHelper.GetParent(rectangulo);
                if (padre is StackPanel stack)
                {
                    if (stack.Name.Equals("Seleccionado"))
                    {
                        Seleccionado.Children.Remove(rectangulo);
                        listaSeleccionados.Remove((Partido)rectangulo.Tag);
                        noSeleccionado.Children.Add(rectangulo);
                        listaNoSeleccionados.Add((Partido)rectangulo.Tag);
                    }
                    else if (stack.Name.Equals("noSeleccionado"))
                    {
                        noSeleccionado.Children.Remove(rectangulo);
                        listaNoSeleccionados.Remove((Partido)rectangulo.Tag);
                        Seleccionado.Children.Add(rectangulo);
                        listaSeleccionados.Add((Partido)rectangulo.Tag);
                    }

                    //debemos de volver a calcular la altura proporcional de todos los rectangulos
                    //calculamos el total de diputados en cada columna

                    int dipSeleccionados = 0;
                    int dipNoSeleccionados = 0;

                    foreach (Partido partido in listaSeleccionados)
                    {
                        dipSeleccionados += partido.Num;
                    }
                    foreach (Partido partido in listaNoSeleccionados)
                    {
                        dipNoSeleccionados += partido.Num;
                    }



                    numMayoria.Text = dipSeleccionados.ToString() + "/" + ((dipNoSeleccionados + dipSeleccionados) / 2 + 1).ToString();
                    if (dipSeleccionados > dipNoSeleccionados)
                    {
                        foreach (Rectangle rectangle in Seleccionado.Children)
                        {
                            Partido partido = (Partido)rectangle.Tag;
                            rectangle.Height = partido.Num * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipSeleccionados;
                        }
                        foreach (Rectangle rectangle in noSeleccionado.Children)
                        {
                            Partido partido = (Partido)rectangle.Tag;
                            rectangle.Height = partido.Num * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipSeleccionados;
                        }
                        lineaMayoria.Y1 = (gridPactometro.RowDefinitions[1].ActualHeight) - (((dipNoSeleccionados + dipSeleccionados) / 2 + 1) * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipSeleccionados);
                        lineaMayoria.Y2 = lineaMayoria.Y1;
                        numMayoria.Margin = new Thickness(0, 0, 0, (((dipNoSeleccionados + dipSeleccionados) / 2 + 1) * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipSeleccionados));
                    }
                    else
                    {
                        foreach (Rectangle rectangle in Seleccionado.Children)
                        {
                            Partido partido = (Partido)rectangle.Tag;
                            rectangle.Height = partido.Num * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipNoSeleccionados;
                        }
                        foreach (Rectangle rectangle in noSeleccionado.Children)
                        {
                            Partido partido = (Partido)rectangle.Tag;
                            rectangle.Height = partido.Num * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipNoSeleccionados;
                        }
                        lineaMayoria.Y1 = (gridPactometro.RowDefinitions[1].ActualHeight) - (((dipNoSeleccionados + dipSeleccionados) / 2 + 1) * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipNoSeleccionados);
                        lineaMayoria.Y2 = lineaMayoria.Y1;
                        numMayoria.Margin = new Thickness(0, 0, 0, (((dipNoSeleccionados + dipSeleccionados) / 2 + 1) * (gridPactometro.RowDefinitions[1].ActualHeight - 15) / dipSeleccionados));
                    }
                }

                //COMPROBAMOS
                int total = 0;
                String listaCoalicion = "";
                foreach (Partido partido in listaSeleccionados)
                {
                    total += partido.Num;
                    listaCoalicion += partido.NombrePartido;
                    listaCoalicion += "(" + partido.Num.ToString() + ") ";
                }

                if (total >= mayoria)
                {
                    MessageBoxResult resultado;

                    resultado = MessageBox.Show("Se ha alcanzado mayoria absoluta por una coalicion formada por los partidos: " + listaCoalicion, "COALICION ALCANZADA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    if (resultado == MessageBoxResult.Yes)
                    {



                    }
                }
            }
        }
    }
}
