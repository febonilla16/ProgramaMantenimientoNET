using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para FormAgregar.xaml
    /// </summary>
    public partial class FormAgregar : Window
    {
        public FormAgregar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (nombretxt.Text!="" && apellidotxt.Text != "" && telefonotxt.Text != "")
            {
                Clientes cliente = new Clientes();
                cliente.Nombres = nombretxt.Text;
                cliente.Apellidos = apellidotxt.Text;
                cliente.Telefono = Convert.ToInt32(telefonotxt.Text);
                cliente.Insertar();
                MessageBox.Show("Registro agregado correctamente", "Nuevo registro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Campos vacíos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
