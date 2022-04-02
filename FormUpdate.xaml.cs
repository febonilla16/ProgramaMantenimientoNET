using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgramaMantenimiento
{
    /// <summary>
    /// Lógica de interacción para FormUpdate.xaml
    /// </summary>
    public partial class FormUpdate : Window
    {
        Clientes cl = new Clientes();
        public FormUpdate()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (codigotxt.Text!="")
            {
                btn_modificar.Visibility = Visibility.Visible;
                btn_eliminar.Visibility = Visibility.Visible;
                nombretxt.Visibility = Visibility.Visible;
                apellidotxt.Visibility = Visibility.Visible;
                telefonotxt.Visibility = Visibility.Visible;
                cl = Clientes.Ver(Convert.ToInt32(codigotxt.Text));
                nombretxt.Text = cl.Nombres.ToString();
                apellidotxt.Text = cl.Apellidos.ToString();
                telefonotxt.Text = cl.Telefono.ToString();
            }
            else
            {
                MessageBox.Show("Debe introducir un ID", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void codigotxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Clientes.Eliminar(Convert.ToInt32(codigotxt.Text));
            codigotxt.Clear();
            nombretxt.Clear();
            apellidotxt.Clear();
            telefonotxt.Clear();
            btn_modificar.Visibility = Visibility.Hidden;
            btn_eliminar.Visibility = Visibility.Hidden;
            nombretxt.Visibility = Visibility.Hidden;
            apellidotxt.Visibility = Visibility.Hidden;
            telefonotxt.Visibility = Visibility.Hidden;
            MessageBox.Show("Registro eliminado correctamente", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            if (nombretxt.Text!="" && apellidotxt.Text != "" && telefonotxt.Text != "")
            {
                cl.Nombres = nombretxt.Text.ToString();
                cl.Apellidos = apellidotxt.Text.ToString();
                cl.Telefono = Convert.ToInt32(telefonotxt.Text.ToString());
                cl.Modificar();
                codigotxt.Clear();
                nombretxt.Clear();
                apellidotxt.Clear();
                telefonotxt.Clear();
                btn_modificar.Visibility = Visibility.Hidden;
                btn_eliminar.Visibility = Visibility.Hidden;
                nombretxt.Visibility = Visibility.Hidden;
                apellidotxt.Visibility = Visibility.Hidden;
                telefonotxt.Visibility = Visibility.Hidden;
                MessageBox.Show("Registro modificado correctamente", "Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Debe introducir datos en los campos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
