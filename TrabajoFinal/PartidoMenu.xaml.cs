using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace TrabajoFinalAlejandroAceves
{
    /// <summary>
    /// Lógica de interacción para PartidoMenu.xaml
    /// </summary>
    public partial class PartidoMenu : Window
    {
        ObservableCollection<Partido> partidos;
        Partido partido;
        Partido partidoAntiguo;
        Color colorPartido = new Color();

        Boolean modificando;


        /*
         * CONSTRUCTORES
         */
        public PartidoMenu(ObservableCollection<Partido> lista)
        {
            InitializeComponent();
            partidos = lista;

            //color por defecto gris
            colorPartido.R = 128;
            colorPartido.G = 128;
            colorPartido.B = 128;

            sliderRojo.Value = 128;
            sliderVerde.Value = 128;
            sliderAzul.Value = 128;
        }

        public PartidoMenu(ObservableCollection<Partido> lista, Partido selected)
        {
            InitializeComponent();

            lista.IndexOf(selected);

            sliderRojo.Value = selected.Color.R;
            sliderVerde.Value = selected.Color.G;
            sliderAzul.Value = selected.Color.B;

            partidos = lista;
            modificando = true;

            partidoAntiguo = selected;


            name.Text = selected.NombrePartido;
            numRep.Text = selected.Num.ToString();
            colorPartido = selected.Color;

        }


        /*
         * METODOS BOTONES
         */
        private void Aceptar_Button_Click(object sender, RoutedEventArgs e)
        {
            //solo se añaden valores
            int i = 0;
            string s = numRep.Text;

            bool result = int.TryParse(s, out i);
            if (result == false || i <= 0)
            {
                MessageBox.Show("El numero de diputados del partido debe de ser un numero y mayor que 0", "Error en los datos", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            else
            {
                if (name.Text == "")
                {
                    MessageBox.Show("El nombre del partido no puede estar vacio", "Error en los datos", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
                else
                {
                    //el color del partido nunca puede ser nulo por eso no se comprueba
                    partido = new Partido(name.Text, i, colorPartido);

                    if (modificando == true)
                    {
                        if (partidos.IndexOf(partidoAntiguo) != -1)
                        {
                            partidos[partidos.IndexOf(partidoAntiguo)] = partido;
                        }
                    }
                    else
                    {
                        partidos.Add(partido);
                    }
                    DialogResult = true;
                }
            }

        }
        private void Rechazar_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        /*
         * METODOS EVENTARGS
         */
        private void slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            byte rojoValor = (byte)sliderRojo.Value;
            byte verdeValor = (byte)sliderVerde.Value;
            byte azulValor = (byte)sliderAzul.Value;

            colorPartido = Color.FromRgb(rojoValor, verdeValor, azulValor);

            previewColor.Fill = new SolidColorBrush(colorPartido);
        }
    }


}
