using System.Windows;
using System.Windows.Input;

namespace TrabajoFinalAlejandroAceves
{
    /// <summary>
    /// Lógica de interacción para InicioAplicacion.xaml
    /// </summary>
    public partial class InicioAplicacion : Window
    {
        public InicioAplicacion()
        {
            InitializeComponent();
        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MainWindow ventanaPrincipal = new MainWindow();
                ventanaPrincipal.Show();
                this.Close();
            }
        }
    }
}
